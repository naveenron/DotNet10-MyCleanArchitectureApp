using Microsoft.EntityFrameworkCore;
using MyCleanArchitectureApp.Application.Commands;
using MyCleanArchitectureApp.Application.Interfaces;
using MyCleanArchitectureApp.Application.Queries;
using MyCleanArchitectureApp.Infrastructure.Data;
using MyCleanArchitectureApp.Infrastructure.Repositories;

namespace MyCleanArchitectureApp.API.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetUserQuery).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateUserCommands).Assembly);
        });

        // In-Memory DB
        services.AddDbContext<ApplicationDBContext>(opt=> opt.UseInMemoryDatabase("CleanDb"));

        // Repo
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
