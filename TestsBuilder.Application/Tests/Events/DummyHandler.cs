using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Domain.Test.Events;

namespace TestsBuilder.Application.Tests.Events
{
    public class DummyHandler : INotificationHandler<TestCreated>
    {
        public Task Handle(
            TestCreated notification,
            CancellationToken cancellationToken
        )
        {
            return Task.CompletedTask;
        }
    }
}
