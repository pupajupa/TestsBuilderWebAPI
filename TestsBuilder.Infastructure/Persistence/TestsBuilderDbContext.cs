using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Test;

namespace TestsBuilder.Infastructure.Persistence
{
    public class TestsBuilderDbContext:DbContext
    {
        public TestsBuilderDbContext(DbContextOptions<TestsBuilderDbContext> options)
            : base(options) { }

        public DbSet<Test> Tests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(TestsBuilderDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
