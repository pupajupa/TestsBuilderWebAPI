using TestsBuilder.Domain.Common.Models;

namespace TestsBuilder.Domain.Test.ValueObjects
{
    public sealed class TestId:ValueObject
    {
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

        public Guid Value { get; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
