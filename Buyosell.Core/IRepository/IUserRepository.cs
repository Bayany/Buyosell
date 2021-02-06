using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(long userId);
        Task<List<Ad>> GetAdsByUserIdAsync(long userId);
        Task<List<Ad>> GetWhishlistByUserIdAsync(long userId);
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(long userId);
        Task CreateAdAsync(long userId,Ad ad);
        Task DeleteAdAsync(long userId,long adId);
        Task BookmarkAdAsync(long userId, long adId);
        Task UnBookmarkAdAsync(long userId, long adId);
        Task CommitAsync();
    }
}