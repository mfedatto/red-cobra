using RedCobra.CrossCutting.CompositionRoot.Extensions;
using RedCobra.WebApi.Extensions;

WebApplication.CreateBuilder(args)
    .AddCompositionRoot()
    .Build()
    .Configure()
    .Run();
