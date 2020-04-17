﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Basics.CustomPolicyProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IAuthorizationService _authorizationService;

        //    public HomeController(IAuthorizationService authorizationService)
        //{
        //    _authorizationService = authorizationService;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SecretRole()
        {
            return View("Secret");
        }

        [SecurityLevel(5)]
        public IActionResult SecretLevel()
        {
            return View("Secret");
        }

        [SecurityLevel(10)]
        public IActionResult SecretHigherLevel()
        {
            return View("Secret");
        }

        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "Bob@fmail.com"),
                new Claim(ClaimTypes.DateOfBirth, "11/11/2000"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "AdminTwo"),
                new Claim(DynamicPilicies.SecurityLevel, "7"),
                new Claim("Grandma.Says", "Very nice boy"),
            };
            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicense", "A+"),
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "GrandmaIdentity");
            var LicenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, LicenseIdentity });

            //----------------------------------------------------------------------------------------------------------------------------------------

            HttpContext.SignInAsync(userPrincipal);


            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DoStuff(
            [FromServices] IAuthorizationService authorizationService)
        {
            // we are doing stuff here

            var builder = new AuthorizationPolicyBuilder("Schema");
            var customPolicy = builder.RequireClaim("Hello").Build();

            var authResult = await authorizationService.AuthorizeAsync(User, customPolicy);

            if (authResult.Succeeded)
            {
                return View("Index");
            }

            return View("Index");
        }



        //public HomeController()
        //{
        //}
    }
}
