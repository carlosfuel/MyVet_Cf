﻿using Microsoft.AspNetCore.Identity;
using MyVet_Cf.Web.Data.Entities;
using MyVet_Cf.Web.Models;
using System.Threading.Tasks;

namespace MyVet_Cf.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        //----------------------------------------------------------
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        //----------------------------------------------------------
    }

}
