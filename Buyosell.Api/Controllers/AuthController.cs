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

namespace Buyosell.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;


        public AuthController(ILogger<AuthController> logger, IAuthService authService, IMapper mapper)
        {
            _logger = logger;
            _authService = authService;
            this._mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authService.GetAllUsers());
        }
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            return Ok(await _authService.GetUserById(id));
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserResource userResource)
        {
            var newUser = _mapper.Map<UserResource, User>(userResource);
            await _authService.CreateUser(newUser);
            return Ok(newUser);
        }
        [HttpDelete("DeleteUser/{userId}")]
        public async Task<ActionResult> DeleteUser(long userId)
        {
            await _authService.DeleteUser(userId);
            return Ok($"The User {userId} deleted successfully");
        }


    }
}
