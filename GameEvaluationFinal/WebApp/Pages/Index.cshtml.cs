using Logic.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Logic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Logic.Filtering_and_Sorting;

namespace WebApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGameAdministration _gameAdministration;
        private readonly IUserAdministration _userAdministration;

        public IndexModel(IGameAdministration gameAdministration, IUserAdministration userAdministration)
        {
            _gameAdministration = gameAdministration;
            _userAdministration = userAdministration;
        }

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedGenre { get; set; }
        public SelectList GenreOptions => new SelectList(new[]
        {
          "Action",
          "Platform",
          "Shooter",
          "Survival",
          "Stealth",
          "Battle Royale",
          "MOBA"
        });
        public List<Game> Games { get; set; }
        public List<Message> Messages { get; set; }

        public SelectList SortingOptions => new SelectList(new[]
        {
             new { ID = "title-asc", Name = "Title (A-Z)" },
             new { ID = "title-desc", Name = "Title (Z-A)" },
             new { ID = "averageScore-asc", Name = "Average Score (Low-High)" },
             new { ID = "averageScore-desc", Name = "Average Score (High-Low)" },
        }, "ID", "Name");

        public async Task OnGetAsync()
        {
            var filterList = new List<IFiltering<Game>>();

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                filterList.Add(new GameFiltering(CurrentFilter));
            }

            if (!string.IsNullOrEmpty(SelectedGenre))
            {
                filterList.Add(new GenreFilter(SelectedGenre));
            }

            var combinedFilter = new CombinedFilter<Game>(filterList);

            IComparer<Game> comparer = null;

            if (!string.IsNullOrEmpty(CurrentSort))
            {
                switch (CurrentSort)
                {
                    case "title-asc":
                        comparer = new GameTitleComparer();
                        break;
                    case "title-desc":
                        comparer = new ReverseComparer<Game>(new GameTitleComparer());
                        break;
                    case "averageScore-asc":
                        comparer = new GameAverageScoreComparer();
                        break;
                    case "averageScore-desc":
                        comparer = new ReverseComparer<Game>(new GameAverageScoreComparer());
                        break;
                    default:
                        throw new ArgumentException($"Invalid sort parameter: {CurrentSort}");
                }
            }

            Games = _gameAdministration.GetAllGamesSorted(combinedFilter, comparer);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Messages = _userAdministration.GetMessagesByUserId(userId)
                .Where(message => !message.IsRead)
                .ToList();
        }

        public async Task<IActionResult> OnPostMarkMessageAsRead(int messageId)
        {
            await _userAdministration.MarkMessageAsRead(messageId);
            return RedirectToPage();
        }

    }
}