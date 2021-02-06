using System.Collections.Generic;
using System.Threading.Tasks;
using Buyosell.Core.IService;
using Buyosell.Core;
using Buyosell.Core.Models;

namespace Buyosell.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllUsersAsync();
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(userId);
        }
        public async Task CreateUser(User user)
        {
            user.PublishedAds = new List<Ad>();
            user.Wishlist = new List<Ad>();
            await _unitOfWork.Users.CreateUserAsync(user);
            await _unitOfWork.Users.CommitAsync();
        }
        public async Task DeleteUser(long userId)
        {
            await _unitOfWork.Users.DeleteUserAsync(userId);
            await _unitOfWork.CommitAsync();
        }


    }
}
