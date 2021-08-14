using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}