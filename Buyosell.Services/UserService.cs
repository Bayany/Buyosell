using System.Collections.Generic;
using System.Threading.Tasks;
using Buyocell.Core.IService;
using Buyosell.Core;
using Buyosell.Core.Models;

namespace Buyosell.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task BookmarkAd(long userId, Ad ad)
        {
             await _unitOfWork.UserFeed.BookmarkAdAsync(userId, ad);
        }
        public async Task UnBookmarkAd(long userId, Ad ad)
        {
             await _unitOfWork.UserFeed.UnBookmarkAdAsync(userId, ad);
        }

        public async Task CreateAd(long userId, Ad ad)
        {
            await _unitOfWork.UserFeed.CreateAdAsync(userId, ad);
        }

        public async Task DeleteAd(long userId, Ad ad)
        {
            await _unitOfWork.UserFeed.DeleteAdAsync(userId, ad);
        }

        public async Task<List<Ad>> GetPublishedAds(long userId)
        {
            return await _unitOfWork.UserFeed.GetAdsByUserIdAsync(userId);
        }

        public async Task<List<Ad>> GetWhishlist(long userId)
        {
            return await _unitOfWork.UserFeed.GetWhishlistByUserIdAsync(userId);
        }


    }
}
