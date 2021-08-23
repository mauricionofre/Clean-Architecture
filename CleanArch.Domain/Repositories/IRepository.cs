using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}