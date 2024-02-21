using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.Domain.AppSettings;

namespace RedCobra.CrossCutting.CompositionRoot;

public class DomainContextBuilder : IContextBuilderInstaller, IContextBuilderConfigBinder
{
    public void Install(WebApplicationBuilder builder)
    {
        //// builder.Services.AddSingleton<>();
    }

    public void BindConfig(
        WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.BindConfig<DatabaseConfig>(configuration);
        builder.BindConfig<TelemetryConfig>(configuration);
    }
}
