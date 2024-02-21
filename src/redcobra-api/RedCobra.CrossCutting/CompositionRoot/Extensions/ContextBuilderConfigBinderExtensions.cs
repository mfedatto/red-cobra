﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCobra.Domain.AppSettings;

namespace RedCobra.CrossCutting.CompositionRoot.Extensions;

public static class ContextBuilderConfigBinderExtensions
{
    public static WebApplicationBuilder BindConfig<T>(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
        where T : class, IConfig, new()
    {
        T configurator = new();

        configuration.GetSection(configurator.Section)
            .Bind(configurator);
        
        builder.Services.AddSingleton(configurator);

        return builder;
    }
}
