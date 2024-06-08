using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Common.Models;

namespace TestsBuilder.Domain.Test.Events
{
    public record TestCreated(Test Test):IDomainEvent;
}
