using System.Threading.Tasks;
using MVCApi.Domain.Entites;

namespace MVCApi.Application
{
    public interface ICurrencyService
    {
        Task<CurrencyProduct> AddConversion(Product product, string currencyCode);
    }
}