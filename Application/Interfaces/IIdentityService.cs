using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIdentityService
    {

        bool CurrentUserHasThisRole(string role);
    }
}
