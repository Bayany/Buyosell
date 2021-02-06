using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.IService;
using Buyosell.Core;
using Buyosell.Core.Models;

namespace Buyosell.Services
{
    public class AdWallService : IAdWallService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdWallService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Ad>> GetAdsByCategory(Category category)
        {
           return await _unitOfWork.Ads.GetAdsByCategoryAsync(category);
        }

        public async Task<List<Ad>> GetAdsByCity(City city)
        {
             return await _unitOfWork.Ads.GetAdsByCityAsync(city);
        }

        public List<Ad> FilterAds(List<Ad>ads, string price)
        {
             return _unitOfWork.Ads.FilterAdsAsync(ads,price);
        }

        public List<Ad> SearchAds(List<Ad>ads, string query)
        {
             return  _unitOfWork.Ads.SearchAdsAsync(ads,query);
        }
    }
}
