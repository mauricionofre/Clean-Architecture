using CleanArch.Domain.Entities;
using System.Collections.Generic;

namespace CleanArch.Domain.Repositories
{
    public interface IFeedbackRepository
    {
        void Add(Feedback feedback);

        IEnumerable<Feedback> GetAll();
    }
}