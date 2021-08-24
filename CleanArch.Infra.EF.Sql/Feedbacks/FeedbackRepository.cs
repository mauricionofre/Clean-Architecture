using CleanArch.Domain;
using CleanArch.Domain.Entities.Feedbacks;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Infra.EF.Sql.Feedbacks
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly SqlDbContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FeedbackRepository(SqlDbContext context)
        {
            _context = context;
        }

        public Result<Exception, Feedback> Add(Feedback feedback)
        {
            if (feedback == null)
                return new NotFoundException();

            return _context.Feedbacks.Add(feedback).Entity;
        }

        public Result<Exception, Feedback> Update(Feedback entity)
        {
            var feedbackResult = _context.Entry(entity);
            feedbackResult.State = EntityState.Modified;

            return feedbackResult.Entity;
        }

        public async Task<Result<Exception, IQueryable<Feedback>>> GetAll()
        {
            return _context.Feedbacks;
        }

        public async Task<Result<Exception, Feedback>> GetById(int id)
        {
            return await _context.Feedbacks.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}