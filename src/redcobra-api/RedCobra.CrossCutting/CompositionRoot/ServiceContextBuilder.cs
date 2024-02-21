using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.Domain.AppSettings;

namespace RedCobra.CrossCutting.CompositionRoot;

public class ServiceContextBuilder : IContextBuilderInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        //// builder.Services.AddSingleton<>();
    }
}
