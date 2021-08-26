using CleanArch.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities.Wallets
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Result<Exception, Wallet> Add(Wallet entity);

        Result<Exception, Wallet> Update(Wallet entity);

        Task<Result<Exception, IQueryable<Wallet>>> GetAll();

        Task<Result<Exception, Wallet>> GetById(int id);
    }
}