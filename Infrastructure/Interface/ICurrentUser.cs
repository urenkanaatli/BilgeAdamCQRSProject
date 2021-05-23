using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Interface
{
    public interface ICurrentUser
    {

        ClaimsPrincipal ApplicationUser { get; }
    }
}
