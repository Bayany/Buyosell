using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IRepository
{
    public interface IAdRepository
    {
        Task<Ad> GetAdByIdAsync(long adId);
        Task<List<Ad>> GetAllAdsAsync();
        Task<List<Ad>> GetAdsByCityAsync(City city);
        Task<List<Ad>> GetAdsByCategoryAsync(Category category);
        Task<List<Ad>> FilterAdsAsync(long minPrice, long maxPrice);
        Task<List<Ad>> SearchAdsAsync(string query, City city, Category category=null);
        Task DeleteAdAsync(long adId);
        Task CommitAsync();
    }
}