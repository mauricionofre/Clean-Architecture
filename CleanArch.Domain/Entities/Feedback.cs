namespace CleanArch.Domain.Entities
{
    public class Feedback
    {
        public long Id { get; set; }
        public string Commentary { get; set; }
        public bool Approved { get; set; }

        public long ToUserId { get; set; }

        public long FromUserId { get; set; }
    }
}