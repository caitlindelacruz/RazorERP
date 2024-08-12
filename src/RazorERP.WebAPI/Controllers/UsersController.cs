using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorERP.Application.Commands.CreateUser;
using RazorERP.Application.Commands.DeleteUser;
using RazorERP.Application.Commands.UpdateUser;
using RazorERP.Application.Queries.GetUser;
using RazorERP.Application.Queries.ListAllUsers;
using RazorERP.Application.Queries.ListNonAdminUsers;
using RazorERP.Domain.Entities;

namespace RazorERP.WebAPI.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ApiController
    {
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetById(int id)
        {
            var user = await Mediator.Send(new GetUserQuery() { Id = id });

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpGet]
        public async Task<ActionResult<ListAllUsersResponse>> GetAll()
        {
            var result = await Mediator.Send(new ListAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("non-admin")]
        public async Task<ActionResult<ListNonAdminUsersResponse>> GetNonAdminUsers()
        {
            var result = await Mediator.Send(new ListNonAdminUsersQuery());
            return Ok(result);
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(UpdateUserCommand command)
        {
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { Id = id });
            if (result)
                return Ok(result);

            return NotFound();
        }
    }
}