﻿using CleanArch.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Result<Exception, Feedback> Add(Feedback entity);

        Result<Exception, Feedback> Update(Feedback entity);

        Task<Result<Exception, IQueryable<Feedback>>> GetAll();

        Task<Result<Exception, Feedback>> GetById(int id);
    }
}