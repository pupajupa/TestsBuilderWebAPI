using TestsBuilder.Domain.Common.Models;
using TestsBuilder.Domain.Test.ValueObjects;

namespace TestsBuilder.Domain.Test.Entities
{
    public sealed class ExampleVariant : Entity<ExampleVariantId>
    {
        public string Number { get; private set; }
        public string Expression { get; private set; }
        public List<string> Answers { get; private set; }
        private ExampleVariant(ExampleVariantId exampleVariantId, string number, string expression, List<string> answers)
            : base(exampleVariantId)
        {
            Number = number;
            Expression = expression;
            Answers = answers;
        }

        private ExampleVariant() : base() { }

        public static  ExampleVariant Create(
            string number,
            string expression,
            List<string> answers)
        {
            return new(ExampleVariantId.CreateUnique(),number, expression,answers);
        }
    }
}
