using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestsBuilder.Application.Tests.Commands.CreateTest;
using TestsBuilder.Contracts.Tests;
using TestsBuilder.Domain.Test.ValueObjects;

namespace TestsBuilder.Api.Controllers
{
    [Route("hosts/{hostId}/tests")]
    public class TestsController:ApiController
    {
        private readonly IMapper _mapper;

        private readonly ISender _mediator;

        public TestsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(
            CreateTestRequest request,
            string hostId)
        {
            var command = _mapper.Map<CreateTestCommand>((request, hostId));

            var createTestResult = await _mediator.Send(command);
            
            return createTestResult.Match(
                test => Ok(_mapper.Map<TestResponse>(test)),
                errors => Problem(errors));
        }
    }
}
