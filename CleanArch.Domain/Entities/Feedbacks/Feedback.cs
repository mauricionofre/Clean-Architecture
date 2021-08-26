using CleanArch.Domain.Enums;
using CleanArch.Domain.Events;
using System;

namespace CleanArch.Domain.Entities.Feedbacks
{
    public class Feedback : Entity, IAggregateRoot
    {
        public string Commentary { get; set; }
        public FeedbackStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }

        public void Approve()
        {
            Status = FeedbackStatusEnum.Approved;
            StatusDescription = null;
            AddDomainEvent(new ApprovedFeedbackDomainEvent(this));
        }

        public void Reject(string description)
        {
            Status = FeedbackStatusEnum.Rejected;
            StatusDescription = description;

            AddDomainEvent(new RejectedFeedbackDomainEvent(this));
        }
    }
}