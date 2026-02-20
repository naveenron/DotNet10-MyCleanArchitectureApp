
using MediatR;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Application.Commands;

public record CreateUserCommands(User user) : IRequest<bool>;
