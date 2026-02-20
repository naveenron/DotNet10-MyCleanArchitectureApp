using MediatR;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Application.Queries;

public record GetUserQuery : IRequest<List<User>>;
