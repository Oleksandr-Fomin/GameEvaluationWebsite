using System;
using System.ComponentModel.DataAnnotations;
using AdministrationLibrary;
using Logic.Entities;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Text.RegularExpressions;
using Logic.Exceptions;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private IUserAdministration userAdmin;

        public RegisterModel(IUserDBHelper userDBHelper)
        {
            userAdmin = new UserAdministration(userDBHelper);
        }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username must contain only alphanumeric characters and underscores.")]
        [BindProperty]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9!@#$%^&*()_+=-]+$", ErrorMessage = "Password contains invalid characters.")]
        [BindProperty]
        public string password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(254, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 254 characters.")]
        [BindProperty]
        public string email { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userName = userName.Trim();
                    email = email.Trim();
                    password = password.Trim();

                    UserAdministration.ValidateUsername(userName);
                    UserAdministration.ValidateEmail(email);

                    string userId = Guid.NewGuid().ToString();

                    User newUser = new User(userId, userName, password, email);
                    bool userSaved = userAdmin.SaveUser(newUser);

                    if (userSaved)
                    {
                        return RedirectToPage("/Login");
                    }
                }

                return Page();
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
                case ErrorCode.InvalidUsername:
                    return "Username must be at least 3 characters and should not contain white spaces.";
                case ErrorCode.InvalidEmail:
                    return "Email must be between 5 and 254 characters.";
                case ErrorCode.InvalidPassword:
                    return "Password must contain at least one uppercase letter, one lowercase letter, one digit";
                case ErrorCode.UserSavingError:
                    return "An error occurred while saving the user.";
                case ErrorCode.GeneralError:
                default:
                    return "An error occurred.";
            }
        }
    }
}