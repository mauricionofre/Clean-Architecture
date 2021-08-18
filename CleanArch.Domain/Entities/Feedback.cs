using CleanArch.Domain.Enums;
using System;

namespace CleanArch.Domain.Entities
{
    public class Feedback
    {
        public long Id { get; set; }
        public string Commentary { get; set; }
        public FeedbackStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public long ToUserId { get; set; }
        public long FromUserId { get; set; }

        public void Approve()
        {
            Status = FeedbackStatusEnum.Approved;
            StatusDescription = null;
        }

        public void Reject(string description)
        {
            Status = FeedbackStatusEnum.Rejected;
            StatusDescription = description;
        }
    }
}