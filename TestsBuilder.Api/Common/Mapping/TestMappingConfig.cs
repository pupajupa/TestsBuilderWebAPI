using Mapster;
using TestsBuilder.Application.Tests.Commands.CreateTest;
using TestsBuilder.Contracts.Tests;
using TestsBuilder.Domain.Test;

using Example = TestsBuilder.Domain.Test.Entities.Example;
using ExampleVariant = TestsBuilder.Domain.Test.Entities.ExampleVariant;

namespace TestsBuilder.Api.Common.Mapping
{
    public class TestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateTestRequest Request, string HostId), CreateTestCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Test, TestResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value);

            config.NewConfig<Example, ExampleResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<ExampleVariant, ExampleVariantResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
