using Microsoft.EntityFrameworkCore;

namespace MVCApi.Services
{
    public class EShopContext : DbContext 
    {
        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {
            
        }
    }
}
