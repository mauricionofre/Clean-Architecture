using CleanArch.Domain;
using CleanArch.Domain.Entities.Feedbacks;
using CleanArch.Domain.Entities.Users;
using CleanArch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.EF.Sql.Contexts
{
    public class SqlDbContext : DbContext, IUnitOfWork
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new FeedbackConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }

        public async Task<Result<Exception, Unit>> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Disparar os eventos de dominio

            var result = await base.SaveChangesAsync(cancellationToken);

            return Unit.Successful;
        }
    }
}