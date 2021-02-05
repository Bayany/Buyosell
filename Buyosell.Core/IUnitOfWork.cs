using System;
using System.Threading.Tasks;
using Buyosell.Core.IRepository;

namespace Buyosell.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserFeed { get; }
        IAdRepository AdWall { get; }
        Task CommitAsync();
    }
}