using Azure.Identity;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.FeatureManagement;
using MyCleanArchitectureApp.API.DI;

var builder = WebApplication.CreateBuilder(args);

// Below configuration is to use Azure App Configuration
string endpoint = Environment.GetEnvironmentVariable("AppConfigEndpoint") ?? "https://my-demo13-ac.azconfig.io";

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(new Uri(endpoint), new DefaultAzureCredential())
           .Select(KeyFilter.Any)
           .ConfigureRefresh(refresh =>
           {
               refresh.Register("Sentinel", refreshAll: true);
           })
           .UseFeatureFlags();
});

builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement();

// Add OpenTelemetry and configure it to use Azure Monitor
builder.Services.AddOpenTelemetry()
    .UseAzureMonitor();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseAzureAppConfiguration();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
