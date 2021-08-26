using CleanArch.Domain.Entities.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.EF.Sql.Wallets
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallet");
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.AvailableAmount).IsRequired();
            builder.Property(s => s.Amount).IsRequired();
            builder.Property(s => s.UserId).IsRequired();
        }
    }
}