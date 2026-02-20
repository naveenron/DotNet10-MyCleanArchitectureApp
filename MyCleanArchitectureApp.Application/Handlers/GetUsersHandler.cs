using MediatR;
using MyCleanArchitectureApp.Application.Interfaces;
using MyCleanArchitectureApp.Application.Queries;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Application.Handlers;

public class GetUsersHandler(IUserRepository _repo) : IRequestHandler<GetUserQuery, List<User>>
{
    public async Task<List<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}
