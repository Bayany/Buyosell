using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buyosell.Core.IService;
using Buyosell.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Buyosell.Api.Resources;
using Buyosell.Api.Resources.Categories;

namespace Buyosell.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserFeedController : ControllerBase
    {
        private readonly IUserFeedService _userFeedService;
        private readonly ILogger<UserFeedController> _logger;
        private readonly IMapper _mapper;


        public UserFeedController(ILogger<UserFeedController> logger, IUserFeedService userFeedService, IMapper mapper)
        {
            _logger = logger;
            _userFeedService = userFeedService;
            this._mapper = mapper;
        }
    


        [HttpGet("GetPublishedAds/{userId}")]
        public async Task<ActionResult<Ad>> GetPublishedAdsByUserId(long userId)
        {
            var ad = await _userFeedService.GetPublishedAds(userId);
            return Ok(ad);
        }
        [HttpGet("GetWhishlist/{userId}")]
        public async Task<ActionResult<Ad>> GetWhishlistByUserId(long userId)
        {
            var ad = await _userFeedService.GetWhishlist(userId);
            return Ok(ad);
        }
        [HttpPost("CreateAd/Car/{userId}")]
        public async Task<ActionResult<Ad>> CreateCarAd(long userId, [FromBody] CarAdResource carAdResource)
        {
            var newAd = _mapper.Map<CarAdResource, Ad>(carAdResource);
            await _userFeedService.CreateAd(userId, newAd);
            return Ok(newAd);
        }
        [HttpPost("CreateAd/Clothes/{userId}")]
        public async Task<ActionResult<Ad>> CreateClothesAd(long userId, [FromBody] ClothesAdResource clothesAdResource)
        {
            var newAd = _mapper.Map<ClothesAdResource, Ad>(clothesAdResource);
            await _userFeedService.CreateAd(userId, newAd);
            return Ok(newAd);
        }
        [HttpPost("CreateAd/RealState/{userId}")]
        public async Task<ActionResult<Ad>> CreateRealStateAd(long userId, [FromBody] RealStateAdResource realStateAdResource)
        {
            var newAd = _mapper.Map<RealStateAdResource, Ad>(realStateAdResource);
            await _userFeedService.CreateAd(userId, newAd);
            return Ok(newAd);
        }
        [HttpDelete("DeleteAd/{userId}/{adId}")]
        public async Task<ActionResult> DeleteAd(long userId,long adId)
        {
            await _userFeedService.DeleteAd(userId,adId);
            return Ok($"The ad {adId} deleted successfully");
        }

    }
}
