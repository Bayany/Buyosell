using System.Threading.Tasks;
using Buyosell.Core;
using Buyosell.Core.IRepository;
using Buyosell.Data.Repositories;

namespace Buyosell.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuyosellContext _context;
        private AdRepository _adRepository;
        private UserRepository _userRepository;

        public UnitOfWork(BuyosellContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IAdRepository Ads => _adRepository = _adRepository ?? new AdRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}