
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Microsoft.Extensions.DependencyInjection;

namespace TraceApi.OpenTelemetry;
public static class ServiceConfiguration
{
    public static void AddTelemetryTrace(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(serviceName: "builder.Environment.ApplicationName"))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());
    }
}
