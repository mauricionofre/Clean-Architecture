using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.EF.Sql.Feedbacks
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly SqlDbContext _context;

        public FeedbackRepository(SqlDbContext context)
        {
            _context = context;
        }

        public void Add(Feedback feedback)
        {
            if (feedback == null)
                return;

            _context.Add(feedback);
            _context.SaveChanges();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks;
        }
    }
}