using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;

namespace Blog.Service.BlogApi.Api.Controllers.v1
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        private string authorizedUserId;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected string AuthorizedUserId
        {
            get
            {
                return authorizedUserId;
            }
            set
            {
                var identity = (ClaimsIdentity)User.Identity;
                authorizedUserId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                               .Select(c => c.Value).SingleOrDefault();
            }
        }
    }
}
