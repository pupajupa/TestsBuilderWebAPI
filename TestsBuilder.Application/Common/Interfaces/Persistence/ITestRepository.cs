using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Test;

namespace TestsBuilder.Application.Common.Interfaces.Persistence
{
    public interface ITestRepository
    {
        void Add(Test test);
    }
}
