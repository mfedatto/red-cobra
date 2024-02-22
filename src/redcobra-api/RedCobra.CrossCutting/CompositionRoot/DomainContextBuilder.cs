using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.Domain.AppSettings;
using RedCobra.Domain.User;

namespace RedCobra.CrossCutting.CompositionRoot;

public class DomainContextBuilder : IContextBuilderInstaller, IContextBuilderConfigBinder
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<UserFactory>();
    }

    public void BindConfig(
        WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.BindConfig<DatabaseConfig>(configuration);
        builder.BindConfig<TelemetryConfig>(configuration);
    }
}
