using System.Threading.Tasks;
using MVCApi.Domain;

namespace MVCApi.Application
{
    public interface IUserService
    {
        Task<IApplicationUser> GetCurrentUser();
        Task<IApplicationUser> CreateUser(string email, string userName, string password);
    }
}