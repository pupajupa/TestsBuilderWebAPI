using TestsBuilder.Domain.Common.Models;

namespace TestsBuilder.Domain.Test.ValueObjects
{
    public sealed class ExampleVariantId : ValueObject
    {
        public Guid Value { get; }

        private ExampleVariantId(Guid value)
        {
            Value = value;
        }

        public static ExampleVariantId CreateUnique()
        {
            return new ExampleVariantId(Guid.NewGuid());
        }

        public static ExampleVariantId Create(Guid value)
        {
            return new ExampleVariantId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
