using ErrorOr;
using MediatR;
using TestsBuilder.Domain.Test;

namespace TestsBuilder.Application.Tests.Commands.CreateTest
{
    public record CreateTestCommand(
        Guid HostId,
        string Name,
        string Description,
        List<ExampleCommand> Examples) : IRequest<ErrorOr<Test>>;

    public record ExampleCommand(
        string Name,
        string Text,
        List<string> BaseAnswers,
        List<ExampleVariantCommand> Variants);

    public record ExampleVariantCommand(
        string Number,
        string Expression,
        List<string> Answers,
        string CorrectAnswer);
}
