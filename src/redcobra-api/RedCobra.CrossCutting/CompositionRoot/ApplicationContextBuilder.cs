using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.Application;
using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.Domain.AppSettings;
using RedCobra.Domain.User;

namespace RedCobra.CrossCutting.CompositionRoot;

public class ApplicationContextBuilder : IContextBuilderInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserApplication, UserApplication>();
    }
}
