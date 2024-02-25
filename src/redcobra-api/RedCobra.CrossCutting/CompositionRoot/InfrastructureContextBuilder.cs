using System.Data.Common;
using Microsoft.AspNetCore.Builder;
using RedCobra.Domain.MainDbContext;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.Domain.Licenses;
using RedCobra.Domain.User;
using RedCobra.Infrastructure.MainDbContext;
using RedCobra.Infrastructure.MainDbContext.Repositories;

namespace RedCobra.CrossCutting.CompositionRoot;

public class InfrastructureContextBuilder : IContextBuilderInstaller
{
    public void Install(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<DbConnection>(sp => sp.GetRequiredService<IUnitOfWork>().Connection);
        builder.Services.AddScoped<DbTransaction>(sp => sp.GetRequiredService<IUnitOfWork>().Transaction!);
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ILicenseRepository, LicenseRepository>();
    }
}
