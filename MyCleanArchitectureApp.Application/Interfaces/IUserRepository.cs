using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Application.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task AddAsync(User user);
}
