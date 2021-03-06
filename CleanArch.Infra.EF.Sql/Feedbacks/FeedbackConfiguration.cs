using CleanArch.Domain.Entities.Feedbacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.EF.Sql.Feedbacks
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Commentary).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.StatusDescription);
            builder.Property(s => s.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(s => s.ToUserId).IsRequired();
            builder.Property(s => s.FromUserId).IsRequired();
        }
    }
}