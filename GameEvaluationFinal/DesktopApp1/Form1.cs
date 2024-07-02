using System.Collections.Generic;
using System.Windows.Forms;
using AdministrationLibrary;
using Logic.Entities;

using Logic;

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        private readonly IGameAdministration _gameAdmin;
        private readonly IUserAdministration _userAdmin;
        private readonly IReviewAdministration _reviewAdmin;
        private readonly Dictionary<string, int> gamesPerGenre = new Dictionary<string, int>();
        private readonly Dictionary<string, Game> _gamesByTitle = new Dictionary<string, Game>();

        public Form1(IGameAdministration gameAdmin, IUserAdministration userAdmin, IReviewAdministration reviewAdmin)
        {
            InitializeComponent();
            _gameAdmin = gameAdmin;
            _userAdmin = userAdmin;
            _reviewAdmin = reviewAdmin;

            _userAdmin.UsernameChanged += UserAdmin_UsernameChanged; 

            this.Load += Form1_Load;
            CLBGenres.ItemCheck += CLBGenres_ItemCheck;
        }

        private void UserAdmin_UsernameChanged(object sender, string newUsername)
        {
            
            MessageBox.Show($"Username has been changed to {newUsername}.");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllGames();
            ShowAllUsers();
            ShowAllReports();
        }

        private void btAddGame_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            string image = tbURL.Text;
            string releaseDate = tbReleaseDate.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(image) || string.IsNullOrWhiteSpace(releaseDate))
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CLBGenres.SelectedItem == null)
            {
                MessageBox.Show("Please select a genre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string genre = CLBGenres.SelectedItem.ToString();

            int gameId = _gameAdmin.GetNextGameId();
            Game newGame = new Game(title, description, image, releaseDate, genre);
            _gameAdmin.AddGame(newGame);

            string genreSpecificParameter = tbGenreSpecific.Text;

            switch (genre)
            {
                case "Platform":
                    _gameAdmin.AddGameToPlatformGameTable(newGame, int.Parse(genreSpecificParameter));
                    break;
                case "Survival":
                    _gameAdmin.AddGameToSurvivalGameTable(newGame, genreSpecificParameter);
                    break;
                case "MOBA":
                    _gameAdmin.AddGameToMOBAGameTable(newGame, int.Parse(genreSpecificParameter));
                    break;
                case "Action":
                    _gameAdmin.AddGameToActionGameTable(newGame, genreSpecificParameter);
                    break;
                case "Stealth":
                    _gameAdmin.AddGameToStealthGameTable(newGame, genreSpecificParameter);
                    break;
                case "Battle Royale":
                    _gameAdmin.AddGameToBattleRoyaleGameTable(newGame, int.Parse(genreSpecificParameter));
                    break;
                case "Shooter":
                    _gameAdmin.AddGameToShooterGameTable(newGame, genreSpecificParameter);
                    break;
            }

            ShowAllGames();
        }

        private void CLBGenres_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < CLBGenres.Items.Count; ++ix)
                    if (e.Index != ix) CLBGenres.SetItemChecked(ix, false);
            }



            string selectedGenre = CLBGenres.Items[e.Index].ToString();

            switch (selectedGenre)
            {
                case "Platform":
                    lblGenreSpecific.Text = "Enter Number of Levels";
                    break;
                case "Survival":
                    lblGenreSpecific.Text = "Enter Environment Type";
                    break;
                case "MOBA":
                    lblGenreSpecific.Text = "Enter Number of Heroes";
                    break;
                case "Action":
                    lblGenreSpecific.Text = "Enter Combat System";
                    break;
                case "Stealth":
                    lblGenreSpecific.Text = "Enter Stealth Mechanics";
                    break;
                case "Battle Royale":
                    lblGenreSpecific.Text = "Enter Player Capacity";
                    break;
                case "Shooter":
                    lblGenreSpecific.Text = "Enter Weapon Types";
                    break;


            }
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



        private void btDeleteGame_Click(object sender, EventArgs e)
        {
            Game selectedGame = (Game)lbAllGames.SelectedItem;
            if (selectedGame == null)
            {
                MessageBox.Show("Please select a game to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this game?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int gameId = selectedGame.GetId();
                _gameAdmin.DeleteGame(gameId);
                ShowAllGames();
            }
        }

        private void ShowAllUsers()
        {
            lbUsers.Items.Clear();
            List<User> users = _userAdmin.GetAllUsers();

            if (users != null)
            {
                foreach (User user in users)
                {
                    lbUsers.Items.Add(user);
                }
            }

            lbUsers.DisplayMember = "username"; 
        }

        private void btChangeUsername_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                string currentUsername = ((User)lbUsers.SelectedItem).Username;
                string newUsername = tbNewUsername.Text;

                if (_userAdmin.UpdateUsername(currentUsername, newUsername))
                {
                   
                    ShowAllUsers();
                }
                else
                {
                    MessageBox.Show("Username update failed");
                }
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }

        private void ShowAllReports()
        {
            lbAllReports.DataSource = null;
            lbAllReports.Items.Clear();

            List<Report> reports = _reviewAdmin.GetAllReports();

            if (reports != null)
            {
                List<string> displayItems = new List<string>();

                foreach (Report report in reports)
                {
                    Review reportedReview = _reviewAdmin.GetReviewById(report.ReviewId);
                    string comment = reportedReview.comment;
                    string displayText = $"{report.ReportText} - Comment: {comment}";
                    displayItems.Add(displayText);
                }

                lbAllReports.DataSource = displayItems;
            }

            lbAllReports.DisplayMember = ""; 
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btDeleteComment_Click(object sender, EventArgs e)
        {
            if (lbAllReports.SelectedItem == null)
            {
                MessageBox.Show("Please select a comment to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedDisplayText = (string)lbAllReports.SelectedItem;

            string reportText = selectedDisplayText.Split(new[] { " - Comment: " }, StringSplitOptions.None)[0];

            Report selectedReport = _reviewAdmin.GetReportByReportText(reportText);
            if (selectedReport == null)
            {
                MessageBox.Show("Please select a report to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int reviewId = selectedReport.ReviewId;
            int reportId = selectedReport.ReportId;

            Review review = _reviewAdmin.GetReviewById(reviewId);
            string userId = review.userId;

            string comment = selectedDisplayText.Split(new[] { " - Comment: " }, StringSplitOptions.None)[1];
            string text = "Your comment was deleted: " + comment;

            _userAdmin.AddMessage(userId, text);

            _reviewAdmin.DeleteReport(reportId);
            _reviewAdmin.DeleteReportedReview(reviewId);
            ShowAllReports();
        }
    }
}