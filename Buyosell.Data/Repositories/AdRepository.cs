using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Buyosell.Data;
using Buyosell.Core.Models;
using Buyosell.Core.Repositories;
using System.Threading.Tasks;
using System;

namespace Buyosell.Data.Repositories
{
    public class AdRepository : IAdRepository, IDisposable
    {
        private BuyosellContext _context;
        private bool disposed = false;

        public AdRepository(BuyosellContext context)
        {
            this._context = context;
        }

        public async Task<List<Ad>> GetAllAdsAsync()
        {
            return await _context.Ads.ToListAsync();
        }

        public async Task<Ad> GetAdByIdAsync(long adId)
        {
            return await _context.Ads.FindAsync(adId);
        }

        public async Task<List<Ad>> GetAdsByCityAsync(City city)
        {
            return await _context.Ads.Where(ad => ad.City == city).ToListAsync();

        }

        public async Task<List<Ad>> GetAdsByCategoryAsync(Category category)
        {
            return await _context.Ads.Where(ad => ad.Category == category).ToListAsync();
        }
        public async Task<List<Ad>> FilterAdsAsync(long minPrice, long maxPrice)
        {
            return await _context.Ads.Where(ad => minPrice <= ad.Price && ad.Price <= maxPrice).ToListAsync();
        }
        public async Task<List<Ad>> SearchAdsAsync(string query, City city, Category category = null)
        {
            List<Ad> resAds = await GetAdsByCityAsync(city);
            List<Ad> foundedAds = resAds.Where(ad => ad.Title.Contains(query)).ToList();
            return(category != null)? foundedAds : foundedAds.Where(ad => ad.Category == category).ToList();
        }
        public async Task InsertAdAsync(Ad ad)
        {
            await _context.Ads.AddAsync(ad);
        }
        public async Task DeleteAdAsync(long adId)
        {
            Ad ad = await _context.Ads.FindAsync(adId);
            _context.Ads.Remove(ad);
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }
}