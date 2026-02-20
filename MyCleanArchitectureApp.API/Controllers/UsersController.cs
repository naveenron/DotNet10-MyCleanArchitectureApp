using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCleanArchitectureApp.Application.Commands;
using MyCleanArchitectureApp.Application.Queries;
using MyCleanArchitectureApp.Domain.Entities;
using System.Net;

namespace MyCleanArchitectureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator _mediatr) : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _mediatr.Send(new GetUserQuery());
            return Ok(users);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            bool isCreated = await _mediatr.Send(new CreateUserCommands(user));
            return Created();
        }
    }
}
