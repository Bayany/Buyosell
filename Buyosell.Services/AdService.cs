using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Buyocell.Core.Services;
using Buyosell.Core;
using Buyosell.Core.Models;

namespace Buyosell.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Ad> GetAdByID(long adId)
        {
            return await _unitOfWork.AdWall.GetAdByIdAsync(adId);
        }

        public async Task<List<Ad>> GetAdsByCategory(Category category)
        {
           return await _unitOfWork.AdWall.GetAdsByCategoryAsync(category);
        }

        public async Task<List<Ad>> GetAdsByCity(City city)
        {
             return await _unitOfWork.AdWall.GetAdsByCityAsync(city);
        }

        public async Task<List<Ad>> FilterAds(long minPrice, long maxPrice)
        {
             return await _unitOfWork.AdWall.FilterAdsAsync(minPrice,maxPrice);
        }

        public async Task<List<Ad>> SearchAds(string query, City city, Category category = null)
        {
             return await _unitOfWork.AdWall.SearchAdsAsync(query,city,category);
        }
    }
}
