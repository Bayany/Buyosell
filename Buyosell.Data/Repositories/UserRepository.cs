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
    public class UserRepository : IUserRepository, IDisposable
    {
        private BuyosellContext _context;
        private bool disposed = false;

        public UserRepository(BuyosellContext context)
        {
            this._context = context;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<List<Ad>> GetAdsByUserIdAsync(long userId)
        {
            User user = await _context.Users.FindAsync(userId);
            return user.PublishedAds;
        }
        public async Task<List<Ad>> GetWhishlistByUserIdAsync(long userId)
        {
            User user = await _context.Users.FindAsync(userId);
            return user.Wishlist;
        }
        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

        }
        public async Task DeleteUserAsync(long userId)
        {
            User user = await _context.Users.FindAsync(userId);
            _context.Users.Remove(user);
        }

        public async Task CreateAdAsync(long userId, Ad ad)
        {
            User user = await _context.Users.FindAsync(userId);
            if (user is null)
                user.PublishedAds = new List<Ad>();
            user.PublishedAds.Add(ad);
        }

        public async Task DeleteAdAsync(long userId, long adId)
        {
            User user = await _context.Users.FindAsync(userId);
            Ad ad = user.PublishedAds.Find(x => x.Id == adId);
            user.PublishedAds.Remove(ad);
        }
        public async Task BookmarkAdAsync(long userId, long adId)
        {
            User user = await _context.Users.FindAsync(userId);
            Ad ad = user.PublishedAds.Find(x => x.Id == adId);
            user.Wishlist.Add(ad);
        }

        public async Task UnBookmarkAdAsync(long userId, long adId)
        {
            User user = await _context.Users.FindAsync(userId);
            Ad ad = user.PublishedAds.Find(x => x.Id == adId);
            user.Wishlist.Remove(ad);
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