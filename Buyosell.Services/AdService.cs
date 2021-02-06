using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.IService;
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
            return await _unitOfWork.Ads.GetAdByIdAsync(adId);
        }

        public async Task BookmarkAd(long userId, long adId)
        {
            await _unitOfWork.Users.BookmarkAdAsync(userId, adId);
        }
        public async Task UnBookmarkAd(long userId, long adId)
        {
            await _unitOfWork.Users.UnBookmarkAdAsync(userId, adId);
        }

    }
}
