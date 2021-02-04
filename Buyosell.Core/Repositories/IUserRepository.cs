using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(long userId);
        Task<List<Ad>> GetAdsByUserIdAsync(long userId);
        Task<List<Ad>> GetWhishlistByUserIdAsync(long userId);
        Task CreateAdAsync(long userId,Ad ad);
        Task DeleteAdAsync(long userId,Ad ad);
        Task BookmarkAdAsync(long userId, Ad ad);
        Task UnBookmarkAdAsync(long userId, Ad ad);
        Task CommitAsync();
    }
}