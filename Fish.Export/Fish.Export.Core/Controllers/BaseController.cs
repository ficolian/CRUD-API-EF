using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fish.Export.Controllers
{
   public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
   
}
