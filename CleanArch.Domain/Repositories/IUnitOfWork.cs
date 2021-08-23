using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Result<Exception, Unit>> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}