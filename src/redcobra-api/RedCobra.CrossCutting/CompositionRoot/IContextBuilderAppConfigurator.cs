using Microsoft.AspNetCore.Builder;

namespace RedCobra.CrossCutting.CompositionRoot;

public interface IContextBuilderAppConfigurator
{
    WebApplication Configure(
        WebApplication app);
}
