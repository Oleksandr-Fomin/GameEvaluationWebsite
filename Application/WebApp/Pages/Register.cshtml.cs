using System;
using System.ComponentModel.DataAnnotations;
using AdministrationLibrary;
using GameEvaluationProject;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private IUserAdministration userAdmin;

        public RegisterModel(IDBHelper dbHelper)
        {
            userAdmin = new UserAdministration(dbHelper);
        }

        [Required(ErrorMessage = "Username is required.")]
        [BindProperty]
        public string userName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [BindProperty]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [BindProperty]
        public string password { get; set; }

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

                    if (!IsValidUsername(userName) || !IsValidEmail(email) || !IsValidPassword(password))
                    {
                        return Page();
                    }

                    string userId = Guid.NewGuid().ToString();
                    User newUser = new User(userId, userName, password, email);
                    bool userSaved = userAdmin.SaveUser(newUser);

                    if (userSaved)
                    {
                        // User successfully saved to the database
                        return RedirectToPage("/Login");
                    }
                    else
                    {
                        // Failed to save user to the database
                        ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                        return Page();
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                return Page();
            }
        }

        private bool IsValidUsername(string username)
        {
            if (username.Length < 3)
            {
                ModelState.AddModelError("", "Username must be at least 3 characters.");
                return false;
            }

            if (username.Any(char.IsWhiteSpace))
            {
                ModelState.AddModelError("", "Remove the white spaces from the username");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (email.Length < 5 || email.Length > 254)
            {
                ModelState.AddModelError("", "Email must be between 5 and 254 characters.");
                return false;
            }

            return true;
        }

        private bool IsValidPassword(string password)
        {
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                ModelState.AddModelError("", "Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
                return false;
            }

            string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";
            if (!password.Any(c => specialCharacters.Contains(c)))
            {
                ModelState.AddModelError("", "Password must contain at least one special character.");
                return false;
            }

            return true;
        }
    }
}