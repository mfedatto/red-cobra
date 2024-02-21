using Microsoft.AspNetCore.Builder;

namespace RedCobra.CrossCutting.CompositionRoot;

public interface IContextBuilderInstaller
{
    void Install(
        WebApplicationBuilder builder);
}