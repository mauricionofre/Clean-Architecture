using CleanArch.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CleanArch.Domain.Notifications
{
    public interface IFeedbackNotification
    {
        Task<Result<Exception, Unit>> CreatedFeedbackAsync(Feedback feedback);

        Task<Result<Exception, Unit>> ApprovedFeedbackAsync(Feedback feedback);
    }
}