using ErrorOr;
using MediatR;
using TestsBuilder.Application.Common.Interfaces.Persistence;
using TestsBuilder.Domain.Host.ValueObjects;
using TestsBuilder.Domain.Test;
using TestsBuilder.Domain.Test.Entities;

namespace TestsBuilder.Application.Tests.Commands.CreateTest
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, ErrorOr<Test>>
    {
        private readonly ITestRepository _testRepository;

        public CreateTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<ErrorOr<Test>> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Create test
            var test = Test.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                examples: request.Examples.ConvertAll(example => Example.Create(
                    name: example.Name,
                    text: example.Text,
                    baseAnswers: example.BaseAnswers,
                    variants: example.Variants.ConvertAll(variant => ExampleVariant.Create(
                        number: variant.Number,
                        expression: variant.Expression,
                        answers: variant.Answers,
                        correctAnswer: variant.CorrectAnswer)))));
            //Persist test
            _testRepository.Add(test);

            //Return test
            return test;
        }
    }
}
