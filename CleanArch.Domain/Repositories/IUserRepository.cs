﻿using CleanArch.Domain.Entities;
using System.Collections.Generic;

namespace CleanArch.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}