using RedCobra.CrossCutting.CompositionRoot.Extensions;

namespace RedCobra.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication Configure(this WebApplication app)
    {
        return ((WebApplication)app.UseMiddleware<HttpContextMiddleware>())
            .ConfigureApp();
    }
}
