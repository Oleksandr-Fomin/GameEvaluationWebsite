using System.Collections.Generic;
using GameEvaluationProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AdministrationLibrary;
using Logic;


namespace WebApp.Pages
{
    [Authorize]
    public class GameDetailsModel : PageModel
    {
        private readonly IGameAdministration _gameAdmin;
        private readonly IReviewAdministration _reviewAdmin;
        public GameDetailsModel(IDBHelper dbHelper)
        {
            _gameAdmin = new GameAdministration(dbHelper);
            _reviewAdmin = new ReviewAdministration(dbHelper);
        }
        public Game game { get; set; }
        public List<Review> reviews { get; set; }

        public double averageScore { get; set; }

        [BindProperty]
        public int GameId { get; set; }

        public void OnGet(int gameId)
        {
            try
            {
                game = _gameAdmin.GetGameById(gameId);
                averageScore = _reviewAdmin.GetAverageScore(gameId);

                if (game == null)
                {
                    RedirectToPage("/Index");
                    return;
                }

                reviews = _reviewAdmin.GetReviewsByGameId(gameId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while fetching the game details. Please try again.");
            }
        }
        public async Task<IActionResult> OnPostAsync(int rating, string comment)
        {
            try
            {
                var dbHelper = new DBHelper();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    dbHelper.AddReview(GameId, userId, rating, comment);
                    OnGet(GameId);
                    return RedirectToPage("/GameDetails", new { gameId = GameId });
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while posting the review. Please try again.");
                return Page();
            }
        }
    }
}
