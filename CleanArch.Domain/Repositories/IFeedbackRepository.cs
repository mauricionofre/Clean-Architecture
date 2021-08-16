using CleanArch.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task<Result<Exception, Feedback>> AddAsync(Feedback entity);

        Task<Result<Exception, IQueryable<Feedback>>> GetAll();
    }
}