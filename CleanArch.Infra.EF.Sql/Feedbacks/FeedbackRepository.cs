using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var feedbackDb = await _context.Set<Feedback>().AddAsync(feedback);
            _context.SaveChanges();

            return feedbackDb.Entity;
        }

        public async Task<Result<Exception, IQueryable<Feedback>>> GetAll()
        {
            return _context.Feedbacks;
        }
    }
}