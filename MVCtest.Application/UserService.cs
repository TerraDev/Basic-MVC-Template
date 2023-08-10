using MVCtest.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace MVCtest.Application
{
    public class UserService
    {

        private readonly UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(string username, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);
        }

        public async Task<IdentityResult> Register(AppUser user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> Register(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task Logout(/* Current User Id */)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> DeleteUser(AppUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> EditUser(AppUser user)
        {
            AppUser newUser = await this.GetUserById(user.Id);
            newUser.UserName = user.UserName;
            newUser.Address = user.Address;
            newUser.Email = user.Email;
            newUser.Latitude = user.Latitude;
            newUser.Longitude = user.Longitude;
            return await _userManager.UpdateAsync(newUser);
        }

        public async Task<IdentityResult> setUserPassword(string userId, string password)
        {
            AppUser newUser = await this.GetUserById(userId);
            newUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newUser, password);
            return await _userManager.UpdateAsync(newUser);
        }

        // System.Security.Claims.ClaimsPrincipal currentUser = this.User; in controller
        public async Task<AppUser> GetCurrentUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        // System.Security.Claims.ClaimsPrincipal currentUser = this.User; in controller
        //current user id is also retrievable from controller (using claims)
        public string GetCurrentUserId(ClaimsPrincipal user)
        {
            return _userManager.GetUserId(user);
        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string userId)
        {
            if(!await _userManager.Users.AnyAsync(x => x.Id == userId))
            {
                throw new Exception("User Id doesn't exist.");
            }

            return await _userManager.Users.Where(x => x.Id == userId).SingleAsync();
        }

        //public string UserFilter(ClaimsPrincipal user)
        //{
        //    return _userManager.GetUserId(user);
        //}
    }
}