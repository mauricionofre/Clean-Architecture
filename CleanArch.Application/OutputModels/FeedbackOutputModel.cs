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

        public int Id { get; set; }
        public string Commentary { get; set; }
        public int ToUserId { get; set; }
        public int FromUserId { get; set; }
        public int Status { get; set; }
    }
}