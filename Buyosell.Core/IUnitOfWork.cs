using System;
using System.Threading.Tasks;
using Buyosell.Core.IRepository;

namespace Buyosell.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAdRepository Ads { get; }
        Task CommitAsync();
    }
}