using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace CleanArch.Infra.Notification
{
    public class FeedbackNotification : IFeedbackNotification
    {
        public async Task<Result<Exception, Unit>> CreatedFeedbackAsync(Feedback feedback)
        {
            return Unit.Successful;
        }
    }
}