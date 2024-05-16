using Microsoft.AspNetCore.Mvc.Infrastructure;
using TestsBuilder.Api.Common.Errors;
using TestsBuilder.Api.Common.Mapping;

namespace TestsBuilder.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, TestsBuilderProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}