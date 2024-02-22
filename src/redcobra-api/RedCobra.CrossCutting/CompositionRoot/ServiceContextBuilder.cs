using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.Domain.AppSettings;
using RedCobra.Domain.User;
using RedCobra.Services;

namespace RedCobra.CrossCutting.CompositionRoot;

public class ServiceContextBuilder : IContextBuilderInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
    }
}
