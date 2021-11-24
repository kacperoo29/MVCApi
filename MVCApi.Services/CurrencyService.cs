using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using MVCApi.Application;
using MVCApi.Domain;
using MVCApi.Domain.Consts;
using MVCApi.Domain.Entites;
using Newtonsoft.Json;

namespace MVCApi.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IDomainRepository<Currency> _currencyRepository;
        private readonly IDomainRepository<Product> _productRepository;

        public CurrencyService(IDomainRepository<Currency> currencyRepository, IDomainRepository<Product> productRepository)
        {
            _currencyRepository = currencyRepository;
            _productRepository = productRepository;
        }

        public async Task<CurrencyProduct> AddConversion(Product product, string currencyCode)
        {
            Currency currency = (await _currencyRepository.GetAllAsync(x => x.Code == currencyCode)).First();
            decimal originalValue = product.Prices.FirstOrDefault(x => x.Currency.Code == EShopConsts.DefaultCurrency).Value;

            HttpClient client = new HttpClient();
            var response = await client.GetStreamAsync($"http://api.nbp.pl/api/exchangerates/rates/a/{currencyCode.ToLower()}/?format=json");

            decimal rate;
            using (var reader = new StreamReader(response))
            {
                var serializer = JsonSerializer.Create();
                var jsonReader = new JsonTextReader(reader);
                dynamic json = serializer.Deserialize(jsonReader);
                rate = json.rates[0].mid;
            }

            CurrencyProduct newConversion = new CurrencyProduct(product, currency, originalValue / rate);
            product.AddConversion(newConversion);
            await _productRepository.EditAsync(product);

            return newConversion;
        }
    }
}