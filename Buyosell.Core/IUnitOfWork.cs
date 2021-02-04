using System;
using System.Threading.Tasks;
using Buyosell.Core.Repositories;

namespace Buyosell.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserFeed { get; }
        IAdRepository AdWall { get; }
        Task CommitAsync();
    }
}