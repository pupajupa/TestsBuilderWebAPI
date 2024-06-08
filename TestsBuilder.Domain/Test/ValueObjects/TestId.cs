using TestsBuilder.Domain.Common.Models;

namespace TestsBuilder.Domain.Test.ValueObjects
{
    public sealed class TestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        private TestId(Guid value)
        {
            Value = value;
        }

        public static TestId CreateUnique()
        {
            return new TestId(Guid.NewGuid());
        }

        public static TestId Create(Guid value)
        {
            return new TestId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}