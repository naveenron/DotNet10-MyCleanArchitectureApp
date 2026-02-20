
using Microsoft.EntityFrameworkCore;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
