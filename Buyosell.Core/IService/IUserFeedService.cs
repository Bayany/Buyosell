using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IService
{
    public interface IUserFeedService {
        Task CreateAd(long userId,Ad ad);
        Task DeleteAd(long userId,long adId);
        Task<List<Ad>> GetWhishlist(long userId);
        Task<List<Ad>> GetPublishedAds(long userId);

    }
    
}