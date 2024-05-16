using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBuilder.Contracts.Tests
{
    public record CreateTestRequest(
        string Name,
        string Description,
        List<Example> Examples);

    public record Example(
        string Text,
        List<string> BaseAnswers,
        List<ExampleVariant> Variants);

    public record ExampleVariant(
        string Number,
        string Expression,
        List<string> Answers);
}
