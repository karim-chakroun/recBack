using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRecrutement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppRecrutement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //Get : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName
              

            };
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "RECRUTEUR")]
        [Route("ForRecruteur")]
        public string GetForRecruteur()
        {
            return "Web method for Recruteur";
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,RECRUTEUR")]
        [Route("ForAdminOrRecruteur")]
        public string GetForAdminOrRecruteur()
        {
            return "Web method for Admin or Recruteur";
        }

        [HttpGet]
        [Authorize(Roles = "CANDIDAT")]
        [Route("ForCandidat")]
        public string GetForCandidat()
        {
            return "Web method for Candidat";
        }

        [HttpGet]
        [Authorize(Roles = "PERSONNEL")]
        [Route("ForPersonnel")]
        public string GetForPersonnel()
        {
            return "Web method for Personnel";
        }
    }
}
