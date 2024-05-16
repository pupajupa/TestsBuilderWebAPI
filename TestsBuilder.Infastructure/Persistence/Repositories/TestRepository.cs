using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Application.Common.Interfaces.Persistence;
using TestsBuilder.Domain.Test;

namespace TestsBuilder.Infastructure.Persistence.Repositories
{
    public class TestRepository : ITestRepository
    { 
        private readonly TestsBuilderDbContext _dbContext;

        public TestRepository(TestsBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Test test)
        {
            _dbContext.Add(test);
            _dbContext.SaveChanges();
        }
    }
}
