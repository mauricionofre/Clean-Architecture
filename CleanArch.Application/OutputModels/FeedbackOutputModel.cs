using CleanArch.Domain.Entities;

namespace CleanArch.Application.InputModels
{
    public struct FeedbackOutputModel
    {
        public FeedbackOutputModel(Feedback feedback)
        {
            Id = feedback.Id;
            Commentary = feedback.Commentary;
            FromUserId = feedback.Id;
            ToUserId = feedback.Id;
            Status = feedback.Status.GetHashCode();
        }

        public long Id { get; set; }
        public string Commentary { get; set; }
        public long ToUserId { get; set; }
        public long FromUserId { get; set; }
        public int Status { get; set; }
    }
}