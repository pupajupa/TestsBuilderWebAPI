using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.Host.ValueObjects;
using TestsBuilder.Domain.Test.Entities;
using TestsBuilder.Domain.Test.Events;
using TestsBuilder.Domain.Test.ValueObjects;

namespace TestsBuilder.Domain.Test
{
    public sealed class Test : AggregateRoot<TestId, Guid>
    {
        // public TestId Id { get; private set; } // Удалено

        private readonly List<Example> _examples = new();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyList<Example> Examples => _examples.AsReadOnly();

        public HostId HostId { get; private set; }

        private Test(
            HostId hostId,
            TestId testId,
            string name,
            string description,
            List<Example>? examples)
            : base(testId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _examples = examples ?? new List<Example>();
        }

        private Test() { }

        public static Test Create(
            HostId hostId,
            string name,
            string description,
            List<Example>? examples = null)
        {
            var test = new Test(
                hostId,
                TestId.CreateUnique(),
                name,
                description,
                examples);

            test.AddDomainEvent(new TestCreated(test));
            return test;
        }
    }

}