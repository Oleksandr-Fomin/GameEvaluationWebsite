using GameEvaluationProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        
       
        public void OnGet()
        {

        }

        
    }
}