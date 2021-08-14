using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.EF.Sql.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _context;

        public UserRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}