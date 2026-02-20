using MediatR;
using MyCleanArchitectureApp.Application.Commands;
using MyCleanArchitectureApp.Application.Interfaces;

namespace MyCleanArchitectureApp.Application.Handlers;

public class CreateUserHandler(IUserRepository _repo) : IRequestHandler<CreateUserCommands, bool>
{
    public async Task<bool> Handle(CreateUserCommands request, CancellationToken cancellationToken)
    {
        await _repo.AddAsync(request.user);
        return true;
    }
}
