using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Buyosell.Data;
using Buyosell.Core.Models;
using Buyosell.Core.IRepository;
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
        public List<Ad> FilterAdsAsync(List<Ad> ads,string price)
        {
            long [] range= price.Split("-").Select(x=>long.Parse(x)).ToArray();
            return ads.Where(ad => range[0] <= ad.Price && ad.Price <=  range[1] ).ToList();
        }
        public List<Ad> SearchAdsAsync(List<Ad> ads,string query)
        {
            return ads.Where(ad => ad.Title.Contains(query)).ToList();
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