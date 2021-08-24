using CleanArch.Domain.Repositories;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.Users
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}