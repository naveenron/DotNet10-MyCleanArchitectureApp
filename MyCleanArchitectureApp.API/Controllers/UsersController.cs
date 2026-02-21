using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using MyCleanArchitectureApp.Application.Commands;
using MyCleanArchitectureApp.Application.Queries;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediatr, ILogger<UsersController> logger, IConfiguration config) : ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            logger.LogInformation("GetUsers method starts");
            string testValue = config["Test"] ?? "Not Found";
            List<User> users = await mediatr.Send(new GetUserQuery());
            logger.LogInformation($"GetUsers method ends {testValue}");
            return Ok(users);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            bool isCreated = await mediatr.Send(new CreateUserCommands(user));
            return Created();
        }

        [FeatureGate("NewCheckout")]
        [HttpGet("new-checkout")]
        public IActionResult NewCheckout()
        {
            return Ok("New checkout enabled!");
        } 
    }
}
