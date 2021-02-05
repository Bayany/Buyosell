using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyocell.Core.IService
{
    public interface IUserService {
        Task CreateAd(long userId,Ad ad);
        Task DeleteAd(long userId,Ad ad);
        Task BookmarkAd(long userId,Ad ad);
        Task UnBookmarkAd(long userId,Ad ad);

        Task<List<Ad>> GetWhishlist(long userId);
        Task<List<Ad>> GetPublishedAds(long userId);

    }
    
}