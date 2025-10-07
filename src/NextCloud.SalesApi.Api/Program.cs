using NextCloud.SalesApi.Api;
using NextCloud.SalesApi.Application;
using NextCloud.SalesApi.Domain;
using NextCloud.SalesApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddApplication()
    .AddDomain()
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
