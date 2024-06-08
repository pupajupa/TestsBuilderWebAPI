using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.Test;
using TestsBuilder.Domain.User;
using TestsBuilder.Infastructure.Persistence.Interceptors;

namespace TestsBuilder.Infastructure.Persistence
{
    public class TestsBuilderDbContext:DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public TestsBuilderDbContext(DbContextOptions<TestsBuilderDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
            : base(options) 
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(TestsBuilderDbContext).Assembly);   

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .AddInterceptors(_publishDomainEventsInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
