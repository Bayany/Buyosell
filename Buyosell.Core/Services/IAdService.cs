using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyocell.Core.Services
{
    public interface IAdService {
        Task<Ad> GetAdByID(long adId);
        Task<List<Ad>> GetAdsByCity(City city);
        Task<List<Ad>> GetAdsByCategory(Category category);
        Task<List<Ad>> SearchAds(string query,City city,Category category=null);
        Task<List<Ad>> FilterAds(long minPrice,long maxPrice);
    }
}