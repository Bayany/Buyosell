using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.Models;

namespace Buyosell.Core.IService
{
    public interface IAdWallService {
  
        Task<List<Ad>> GetAdsByCity(City city);
        Task<List<Ad>> GetAdsByCategory(Category category);
        List<Ad> SearchAds(List<Ad> ads,string query);
        List<Ad> FilterAds(List<Ad> ads,string price);
    }
}