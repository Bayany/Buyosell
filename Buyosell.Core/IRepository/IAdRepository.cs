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
        List<Ad> FilterAdsAsync(List<Ad>ads, string price);
        List<Ad> SearchAdsAsync(List<Ad> ads,string query);
        Task DeleteAdAsync(long adId);
        Task CommitAsync();
    }
}