using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buyosell.Core.IService;
using Buyosell.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
namespace Buyosell.Api.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;
        private readonly ILogger<AdController> _logger;
        private readonly IMapper _mapper;

        public AdController(ILogger<AdController> logger, IAdService adService, IMapper mapper)
        {
            _logger = logger;
            _adService = adService;
            _mapper = mapper;
        }
 


        [HttpGet("GetAd/{adId}")]
        public async Task<ActionResult<Ad>> GetAdById(long adId)
        {
            var ad = await _adService.GetAdByID(adId);
            return Ok(ad);
        }
        [HttpGet("BookmarkAd/{userId}/{adId}")]
        public async Task<ActionResult<Ad>> Bookmark(long userId, long adId)
        {
            await _adService.BookmarkAd(userId,adId);
            return Ok("The ad {adId} bookmarked successfully");
        }
        [HttpDelete("UnBookmarkAd/{userId}/{adId}")]
        public async Task<ActionResult<Ad>> UnBookmark(long userId, long adId)
        {
            await _adService.UnBookmarkAd(userId,adId);
            return Ok("The ad {adId} unbookmarked successfully");
        }


    }
}
