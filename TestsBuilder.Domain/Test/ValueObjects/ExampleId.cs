using TestsBuilder.Domain.Common.Models;

namespace TestsBuilder.Domain.Test.ValueObjects
{
    public sealed class ExampleId : ValueObject
    {
        public Guid Value { get; }

        private ExampleId(Guid value)
        {
            Value = value;
        }

        public static ExampleId CreateUnique()
        {
            return new ExampleId(Guid.NewGuid());
        }

        public static ExampleId Create(Guid value)
        {
            return new ExampleId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
