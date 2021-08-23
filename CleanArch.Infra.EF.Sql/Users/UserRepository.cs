using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Infra.EF.Sql.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public UserRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .AsNoTracking();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}