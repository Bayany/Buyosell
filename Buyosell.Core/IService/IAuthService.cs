using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IService
{
    public interface IAuthService {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(long userId);
        Task CreateUser(User user);
        Task DeleteUser(long userId);

    }
    
}