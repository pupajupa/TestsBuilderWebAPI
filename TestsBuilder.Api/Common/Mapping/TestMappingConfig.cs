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
            config.ForType<Test, TestResponse>()
                .Map(dest => dest.Id, src => GetTestId(src))
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest=>dest.Examples,src=>src.Examples);

            config.ForType<(CreateTestRequest Request, Guid HostId), CreateTestCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest.Name, src => src.Request.Name)
                .Map(dest => dest.Description, src => src.Request.Description)
                .Map(dest=>dest.Examples,src=>src.Request.Examples);

            config.ForType<Example, ExampleResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.ForType<ExampleVariant, ExampleVariantResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }

        private Guid GetTestId(Test test)
        {
            return test.Id.Value;
        }
    }
}
