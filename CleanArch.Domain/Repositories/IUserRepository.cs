using CleanArch.Domain.Entities;
using System.Collections.Generic;

namespace CleanArch.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(long id);
    }
}