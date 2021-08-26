using CleanArch.Domain.Entities.Feedbacks;
using MediatR;

namespace CleanArch.Domain.Events
{
    public class RejectedFeedbackDomainEvent : INotification
    {
        public Feedback Feedback { get; }

        public RejectedFeedbackDomainEvent(Feedback feedback)
        {
            Feedback = feedback;
        }
    }
}