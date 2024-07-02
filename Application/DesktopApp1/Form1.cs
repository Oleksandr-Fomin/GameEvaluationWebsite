using System.Collections.Generic;
using System.Windows.Forms;
using AdministrationLibrary;
using GameEvaluationProject;

using Logic;

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        private readonly IGameAdministration _gameAdmin;
        private readonly Dictionary<string, int> gamesPerGenre = new Dictionary<string, int>();
        private readonly Dictionary<string, Game> _gamesByTitle = new Dictionary<string, Game>();

        public Form1(IGameAdministration gameAdmin)
        {
            InitializeComponent();
            _gameAdmin = gameAdmin;
            //LoadGames();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllGames();
        }

        private void btAddGame_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            string image = tbURL.Text;
            string releaseDate = tbReleaseDate.Text;

            List<string> genres = new List<string>();
            foreach (object itemChecked in CLBGenres.CheckedItems)
            {
                genres.Add(itemChecked.ToString());
            }

            foreach (var genre in genres)
            {
                int gameId = _gameAdmin.GetNextGameId();
                Game newGame = new Game(title, description, image, releaseDate, genre);
                _gameAdmin.AddGame(newGame);
                _gameAdmin.ExportGames(new List<Game> { newGame });
            }

            ShowAllGames();
        }

        private void ShowAllGames()
        {
            lbAllGames.Items.Clear();
            List<Game> games = _gameAdmin.GetAllGames();

            if (games != null)
            {
                foreach (Game game in games)
                {
                    lbAllGames.Items.Add(game);
                }
            }

            
            lbAllGames.DisplayMember = "title";
        }

        private void AddGame(Game game)
        {
            _gameAdmin.AddGame(game);
        }

        private void btDeleteGame_Click(object sender, EventArgs e)
        {
            Game selectedGame = (Game)lbAllGames.SelectedItem;
            int gameId = selectedGame.getId();

            _gameAdmin.DeleteGame(gameId);
            ShowAllGames();
        }

        //private void UpdateGamesPerGenre(string genre)
        //{
        //    if (gamesPerGenre.ContainsKey(genre))
        //    {
        //        gamesPerGenre[genre]++;
        //    }
        //    else
        //    {
        //        gamesPerGenre[genre] = 1;
        //    }
        //}

        //private void LoadGames()
        //{
        //    List<Game> games = _gameAdmin.GetAllGames();

        //    if (games != null)
        //    {
        //        lbAllGames.DataSource = games;

        //        foreach (Game game in games)
        //        {
        //            UpdateGamesPerGenre(game.Genre);
        //        }
        //    }
        //}
    }
}