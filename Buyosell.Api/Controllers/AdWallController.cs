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
    public class AdWallController : ControllerBase
    {
        private readonly IAdWallService _adWallService;
        private readonly ILogger<AdWallController> _logger;
        private readonly IMapper _mapper;

        public AdWallController(ILogger<AdWallController> logger, IAdWallService adWallService, IMapper mapper)
        {
            _logger = logger;
            _adWallService = adWallService;
            _mapper = mapper;
        }

        [HttpGet("GetAds/{city}")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAds(City city, string q, string price)
        {
            var ads = await _adWallService.GetAdsByCity(city);
            if (q !=null)
            {
                ads = _adWallService.SearchAds(ads, q);
            }
            if (price != null)
            {
                ads = _adWallService.FilterAds(ads, price);
            }
            return Ok(ads);
        }
        [HttpGet("GetAds/{city}/{category}")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAdsByCategory(City city, Category category, string q, string price)
        {
            var ads = await _adWallService.GetAdsByCategory(category);
            if (q !=null)
            {
                ads = _adWallService.SearchAds(ads, q);
            }
            if (price != null)
            {
                ads = _adWallService.FilterAds(ads, price);
            }
            return Ok(ads);
        }


    }
}
