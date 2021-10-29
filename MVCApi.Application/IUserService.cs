using System.Threading.Tasks;
using MVCApi.Application;
using MVCApi.Domain.Entites;

namespace MVCApi.Domain
{
    public interface IUserService
    {
        Task<IApplicationUser> GetCurrentUser();
    }
}