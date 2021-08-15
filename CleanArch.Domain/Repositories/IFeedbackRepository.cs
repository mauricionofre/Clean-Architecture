using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Result<Exception, Feedback>> AddAsync(Feedback entity);

        IEnumerable<Feedback> GetAll();
    }
}