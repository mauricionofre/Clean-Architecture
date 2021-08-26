using CleanArch.Domain.Entities.Feedbacks;
using MediatR;

namespace CleanArch.Domain.Events
{
    public class ApprovedFeedbackDomainEvent : INotification
    {
        public Feedback Feedback { get; }

        public ApprovedFeedbackDomainEvent(Feedback feedback)
        {
            Feedback = feedback;
        }
    }
}