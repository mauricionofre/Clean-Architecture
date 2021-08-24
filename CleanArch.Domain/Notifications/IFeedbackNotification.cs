using CleanArch.Domain.Entities.Feedbacks;
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