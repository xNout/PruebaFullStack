using PruebaN5.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddServices();

builder
    .Build()
    .UseServices()
    .Run();