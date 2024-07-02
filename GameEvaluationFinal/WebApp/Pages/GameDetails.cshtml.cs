using System.Collections.Generic;
using Logic.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AdministrationLibrary;
using Logic;
using System.Threading.Tasks;
using Logic.Exceptions;

namespace WebApp.Pages
{
    [Authorize]
    public class GameDetailsModel : PageModel
    {
        private readonly IGameAdministration _gameAdmin;
        private readonly IReviewAdministration _reviewAdmin;

        public GameDetailsModel(IGameDBHelper gameDBHelper, IReviewDBHelper reviewDBHelper)
        {
            _gameAdmin = new GameAdministration(gameDBHelper);
            _reviewAdmin = new ReviewAdministration(reviewDBHelper);
            reviews = new List<Review>();
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
                GameId = game.GetId();

                if (game == null)
                {
                    RedirectToPage("/Index");
                    return;
                }

                reviews = _reviewAdmin.GetReviewsByGameId(gameId);
                averageScore = _reviewAdmin.GetAverageScore(gameId);
            }
            catch (CustomException ex)
            {
                ModelState.AddModelError("", ErrorCodeToString(ex.Code));
            }
            catch (Exception ex)
            {
                throw new CustomException(ErrorCode.GeneralError, ex);
            }
        }

        public async Task<IActionResult> OnPostAsync(int? rating, string comment, string ReportReview, int? reviewId, string reportText)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    if (ReportReview != null)
                    {
                        _reviewAdmin.ReportReview(reviewId.Value, userId, reportText);
                    }
                    else
                    {
                        _reviewAdmin.AddReview(GameId, userId, rating.Value, comment);
                    }

                    return RedirectToPage("/GameDetails", new { gameId = GameId });
                }
                else
                {
                    return RedirectToPage("/Index");
                }
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
                case ErrorCode.GameRetrievalError:
                    return "Failed to retrieve game details. Please try again later.";
                case ErrorCode.ReviewRetrievalError:
                    return "Failed to retrieve reviews. Please try again later.";
                case ErrorCode.ReviewSavingError:
                    return "Failed to save review. Please try again later.";
                case ErrorCode.GeneralError:
                default:
                    return "An unexpected error occurred. Please try again later.";
            }
        }
    }
}