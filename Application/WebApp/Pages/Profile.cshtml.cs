using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using GameEvaluationProject;
using AdministrationLibrary;
using System.Security.Claims;
using Logic;

namespace WebApp.Pages
{
    public class ProfileModel : PageModel
    {
        public User user { get; set; }
        public IUserAdministration userAdmin { get; set; }

        public ProfileModel(IDBHelper dbHelper)
        {
            userAdmin = new UserAdministration(dbHelper);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = userAdmin.GetUserById(userId);

            if (user == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}