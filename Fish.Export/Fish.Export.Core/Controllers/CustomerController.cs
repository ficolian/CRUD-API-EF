using Azure.Core;
using Fish.Application.Model;
using Fish.Application.Usecase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Fish.Export.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseOne<UserCredData>>> AddUser(UserCred request)
        {
            return Ok(await Mediator.Send(request));
        }

    }
}
