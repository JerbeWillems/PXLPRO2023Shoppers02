using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using PXLPRO2023Shoppers02.Data;
using PXLPRO2023Shoppers02.Models;
using System.Security.Claims;
using LoginModel = PXLPRO2023Shoppers02.Models.LoginModel;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace PXLPRO2023Shoppers02.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            // loginlogica nog in verwerken
            LoginModel model = new LoginModel();
            return View(model);
        }
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var searchUser = await _userManager.FindByNameAsync(model.UserName);
                    if (searchUser != null)
                    {
                        await _signInManager.SignInAsync(searchUser, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                }

            }
            return View("Login", model);
        }
        #endregion
        #region FacebookLogin
        [HttpPost]
        public IActionResult FacebookLogin()
        {
            // loginlogica nog in verwerken
            string redirectUrl = Url.Action("FacebookResponse", "Account");
            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }
        public async Task<IActionResult> FacebookResponse()
        {
            ExternalLoginInfo externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                //user did not login properly with facebook -> redirect to login page
                return RedirectToAction(nameof(Login));
            }

            //Put info provided by facebook (claims) into a model
            UserInfoModel userInfo = new UserInfoModel
            {
                UserName = externalLoginInfo.Principal.FindFirst(ClaimTypes.Name).Value,
                Email = externalLoginInfo.Principal.FindFirst(ClaimTypes.Email).Value
            };

            //try to sign in with facebook user id (ProviderKey)
            SignInResult result = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false);
            if (result.Succeeded)
            {
                return View(userInfo);
            }
            IdentityUser newUser = new IdentityUser(userInfo.UserName)
            {
                Email = userInfo.Email
            };
            //Sign in failed -> user does not exist yet in our database -> create one
            IdentityUser user = new IdentityUser(userInfo.UserName)
            {
                Email = userInfo.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user);
            if (identityResult.Succeeded)
            {
                //link the created user to the facebook login info
                identityResult = await _userManager.AddLoginAsync(user, externalLoginInfo);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return View(userInfo);
                }
            }
            return View("AccessDenied");
        }

        #endregion
        #region Register
        public IActionResult Register()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            return View(registrationModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = registrationModel.UserName;
                user.Email = registrationModel.Email;

                var result = await _userManager.CreateAsync(user, registrationModel.Password);

                if (result.Succeeded)
                {
                    // JUISTE ROL NOG TOEVOEGEN
                    await _userManager.AddToRoleAsync(user,/* Settings.Roles.UserRole*/"user" );
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View(registrationModel);
                }
            }
            return View(registrationModel);
        }
        #endregion
        #region Logout
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}


