using CQRS.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Pipelines
{
    public class UserBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext _httpContext;
        public UserBehavior(
                IHttpContextAccessor httpContext
            )
        {
            _httpContext = httpContext.HttpContext;
        }

        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var userId = _httpContext.User.Claims
                .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            if (request is IUserRequest user)
            {
                user.UserId = "woop";
            }
            return next();
        }
    }
}
