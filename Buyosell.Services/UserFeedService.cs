using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.IService;
using Buyosell.Core;
using Buyosell.Core.Models;

namespace Buyosell.Services
{
    public class UserFeedService : IUserFeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserFeedService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task CreateAd(long userId, Ad ad)
        {
            await _unitOfWork.Users.CreateAdAsync(userId, ad);
            await _unitOfWork.Users.CommitAsync();
        }

        public async Task DeleteAd(long userId, long adId)
        {
            await _unitOfWork.Users.DeleteAdAsync(userId, adId);
            await _unitOfWork.Users.CommitAsync();
        }

        public async Task<List<Ad>> GetPublishedAds(long userId)
        {
            return await _unitOfWork.Users.GetAdsByUserIdAsync(userId);
        }

        public async Task<List<Ad>> GetWhishlist(long userId)
        {
            return await _unitOfWork.Users.GetWhishlistByUserIdAsync(userId);
        }


    }
}
