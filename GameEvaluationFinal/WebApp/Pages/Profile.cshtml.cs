using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Logic.Entities;
using AdministrationLibrary;
using System.Security.Claims;
using Logic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class ProfileModel : PageModel
    {
        public User user { get; set; }
        public IUserAdministration userAdmin { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username must contain only alphanumeric characters and underscores.")]
        public string NewUsername { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string NewEmail { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        public ProfileModel(IUserDBHelper dbHelper)
        {
            userAdmin = new UserAdministration(dbHelper);
        }

        public IActionResult OnGet()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = userAdmin.GetUserById(userId);

            if (user == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                user = userAdmin.GetUserById(userId);

                if (user != null)
                {
                    user.username = NewUsername;
                    user.email = NewEmail;
                    user.password = NewPassword; 

                    userAdmin.UpdateUser(user);
                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }

            return RedirectToPage();
        }
    }
}