using GameEvaluationProject;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IGameAdministration _gameAdministration;

        public HomeModel(IGameAdministration gameAdministration)
        {
            _gameAdministration = gameAdministration;
        }

        public Game BestRatedGame { get; set; }
        public List<Game> GoodRatedGames { get; set; }

        public void OnGet()
        {
            var games = _gameAdministration.GetGamesSortedByAverageScore();
            if (games.Count > 0)
            {
                BestRatedGame = games[0];
                GoodRatedGames = games.GetRange(1, games.Count - 1);
            }
        }
    }
}
