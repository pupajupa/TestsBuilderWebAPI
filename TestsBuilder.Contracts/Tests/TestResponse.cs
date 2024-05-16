using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBuilder.Contracts.Tests
{
    public record TestResponse(
        string Id,
        string Name,
        string Description,
        List<ExampleResponse> Examples,
        string HostId);

    public record ExampleResponse(
        string Id,
        string Text,
        List<string> BaseAnswers,
        List<ExampleVariantResponse> Variants);

    public record ExampleVariantResponse(
        string Id,
        string Number,
        string Expression,
        List<string> Answers);
}
