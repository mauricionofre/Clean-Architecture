using CleanArch.Domain;
using CleanArch.Domain.Entities;
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

        public FeedbackRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Exception, Feedback>> AddAsync(Feedback feedback)
        {
            if (feedback == null)
                return new NotFoundException();

            var feedbackDb = await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return feedbackDb.Entity;
        }

        public async Task<Result<Exception, Feedback>> UpdateAsync(Feedback entity)
        {
            var feedbackResult = _context.Feedbacks.Update(entity);
            await _context.SaveChangesAsync();

            return feedbackResult.Entity;
        }

        public async Task<Result<Exception, IQueryable<Feedback>>> GetAll()
        {
            return _context.Feedbacks;
        }

        public async Task<Result<Exception, Feedback>> GetById(long id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}