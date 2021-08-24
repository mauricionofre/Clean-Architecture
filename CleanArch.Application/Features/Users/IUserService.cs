using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Users
{
    public interface IUserService
    {
        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}