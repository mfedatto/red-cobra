using Microsoft.AspNetCore.Builder;
using RedCobra.Domain.MainDbContext;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.Infrastructure.MainDbContext;

namespace RedCobra.CrossCutting.CompositionRoot;

public class InfrastructureContextBuilder : IContextBuilderInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
