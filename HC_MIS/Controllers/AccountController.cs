using HC_MIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }
        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> PostLoginUser(ApplicationUserModel model)
        {
            try
            {
                var modal = new AngularUserDetails();
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result)
                {

                    modal.FirstName = user.FirstName;
                    modal.LastName = user.LastName;
                    modal.UserName = user.UserName;
                    modal.ProfilePicture = user.ProfilePicture;
                    modal.UserRole = (List<string>)await _userManager.GetRolesAsync(user);
                    return Ok(modal);

                }
                else
                {
                    return StatusCode(500, "Error");
                }

                // return StatusCode(200, result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
