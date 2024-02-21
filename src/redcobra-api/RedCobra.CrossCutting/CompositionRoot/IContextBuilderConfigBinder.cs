using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace RedCobra.CrossCutting.CompositionRoot;

public interface IContextBuilderConfigBinder
{
    void BindConfig(
        WebApplicationBuilder builder,
        IConfiguration configuration);
}