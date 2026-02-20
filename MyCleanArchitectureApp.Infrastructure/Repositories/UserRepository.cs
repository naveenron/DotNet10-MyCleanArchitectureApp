using Microsoft.EntityFrameworkCore;
using MyCleanArchitectureApp.Application.Interfaces;
using MyCleanArchitectureApp.Domain.Entities;
using MyCleanArchitectureApp.Infrastructure.Data;

namespace MyCleanArchitectureApp.Infrastructure.Repositories;

public class UserRepository(ApplicationDBContext _context) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await _context.AddAsync(user);
        _context.SaveChanges();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}
