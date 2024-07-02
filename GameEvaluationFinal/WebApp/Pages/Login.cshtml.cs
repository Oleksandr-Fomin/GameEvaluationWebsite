using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AdministrationLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Exceptions;
using Logic.Entities;
using Logic;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {

        private IUserAdministration userAdmin;

        public LoginModel(IUserDBHelper userDBHelper)
        {
            userAdmin = new UserAdministration(userDBHelper);
        }


        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username must contain only alphanumeric characters and underscores.")]
        public string userName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*()_+=-]+$", ErrorMessage = "Password contains invalid characters.")]
        public string password { get; set; }



        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string username = userName.Trim().ToLower();
                string password = this.password.Trim();

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    throw new CustomException(ErrorCode.InvalidCredentials);
                }

                Account user = userAdmin.VerifyUser(username, password);

                if (user == null)
                {
                    throw new CustomException(ErrorCode.InvalidCredentials);
                }

                List<Claim> lst = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.GetId().ToString()),
            new Claim(ClaimTypes.Name, user.GetUsername()),
        };

                ClaimsIdentity ci = new ClaimsIdentity(lst,
                    Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(cp);

                return RedirectToPage("/Index");
            }
            catch (CustomException ex)
            {
                ModelState.AddModelError("", ErrorCodeToString(ex.Code));
                return Page();
            }
            catch (Exception ex)
            {
                throw new CustomException(ErrorCode.GeneralError, ex);
            }
        }

        private string ErrorCodeToString(ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.InvalidCredentials:
                    return "Both username and password fields must be filled, and they must match our records.";
                case ErrorCode.GeneralError:
                default:
                    return "An unexpected error occurred. Please try again later.";
            }
        }


    }

}