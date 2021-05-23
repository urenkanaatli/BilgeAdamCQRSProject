using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Application.Interfaces;

namespace Application.Common
{
    public class ApplicationAuthorizePipiline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IIdentityService identityService;

        public ApplicationAuthorizePipiline(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            ApplicationAuthorize applicationAuthorize = request.GetType().GetCustomAttribute<ApplicationAuthorize>();


            if (applicationAuthorize != null)
            {
                if (!string.IsNullOrEmpty(applicationAuthorize.Role))
                {

                    bool result = identityService.CurrentUserHasThisRole(applicationAuthorize.Role);

                    if (!result)
                        throw new UnauthorizedAccessException();
                }



            }


            return await next();
        }
    }
}
