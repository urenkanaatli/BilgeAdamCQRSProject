using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICurrentUser currentUser;

        public IdentityService(UserManager<ApplicationUser> userManager, ICurrentUser currentUser)
        {
            this.userManager = userManager;
            this.currentUser = currentUser;
        }

        public bool CurrentUserHasThisRole(string role)
        {

            ApplicationUser cUser = userManager.GetUserAsync(currentUser.ApplicationUser).Result;

            return userManager.IsInRoleAsync(cUser, role).Result;

       
        }
    }
}
