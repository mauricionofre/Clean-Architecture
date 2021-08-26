using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.Feedbacks;
using CleanArch.Domain.Entities.Users;
using CleanArch.Domain.Entities.Wallets;
using CleanArch.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.EF.Sql.Contexts
{
    public class SqlDbContext : DbContext, IUnitOfWork
    {
        private IMediator _mediator;

        public SqlDbContext(DbContextOptions<SqlDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

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

        public async Task<Result<Exception, Domain.Unit>> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = this.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);

            var result = await base.SaveChangesAsync(cancellationToken);

            return Domain.Unit.Successful;
        }
    }
}