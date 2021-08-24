namespace CleanArch.Domain.Entities.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}