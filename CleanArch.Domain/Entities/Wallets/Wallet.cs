namespace CleanArch.Domain.Entities.Wallets
{
    public class Wallet : Entity, IAggregateRoot
    {
        public int AvailableAmount { get; set; }

        public int Amount { get; set; }

        public int UserId { get; set; }
    }
}