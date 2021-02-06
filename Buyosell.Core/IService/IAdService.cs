using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IService
{
    public interface IAdService
    {
        Task<Ad> GetAdByID(long adId);
        Task BookmarkAd(long userId, long adId);
        Task UnBookmarkAd(long userId, long adId);
    }
}