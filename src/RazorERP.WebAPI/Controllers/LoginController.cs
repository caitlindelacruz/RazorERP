using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorERP.Application.Commands.CreateUser;
using RazorERP.Application.Commands.LoginUser;
using RazorERP.Application.Queries.GetUser;

namespace RazorERP.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Post(LoginUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}