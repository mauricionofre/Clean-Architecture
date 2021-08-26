using CleanArch.Domain;
using CleanArch.Domain.Entities.Wallets;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Infra.EF.Sql.Wallets
{
    public class WalletRepository : IWalletRepository
    {
        private readonly SqlDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public WalletRepository(SqlDbContext context)
        {
            _context = context;
        }

        public Result<Exception, Wallet> Add(Wallet Wallet)
        {
            if (Wallet == null)
                return new NotFoundException();

            return _context.Wallets.Add(Wallet).Entity;
        }

        public Result<Exception, Wallet> Update(Wallet entity)
        {
            var WalletResult = _context.Entry(entity);
            WalletResult.State = EntityState.Modified;

            return WalletResult.Entity;
        }

        public async Task<Result<Exception, IQueryable<Wallet>>> GetAll()
        {
            return _context.Wallets;
        }

        public async Task<Result<Exception, Wallet>> GetById(int id)
        {
            return await _context.Wallets.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}