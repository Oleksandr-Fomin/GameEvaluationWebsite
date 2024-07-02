using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    
    public class Administration
    {
        

        public List<Game> games = new List<Game>
        {
            new Game ("Dota 2", "game description", "https://cdn.akamai.steamstatic.com/steam/apps/570/capsule_616x353.jpg?t=1677268716", "13.02.2007"),
            new Game ("Hogwarts Legacy", "game description", "https://cdn1.epicgames.com/offer/e97659b501af4e3981d5430dad170911/EGS_HogwartsLegacy_AvalancheSoftware_S1_2560x1440-2baf3188eb3c1aa248bcc1af6a927b7e", "14.02.2008"),
            new Game ("Atomic Heart", "game description", "https://assets2.rockpapershotgun.com/Atomic-Heart-Granny-Zina.png/BROK/resize/1920x1920%3E/format/jpg/quality/80/Atomic-Heart-Granny-Zina.png", "14.02.2008"),
            new Game ("Sons of the Forest", "game description", "https://cdn.akamai.steamstatic.com/steam/apps/1326470/capsule_616x353.jpg?t=1677179639", "14.02.2008")
        };

        public List<User> user = new List<User>
        {

        };

        public void AddGame(string title, string Description, string image, string releaseDate)
        {
            games.Add(new Game(title, Description, image, releaseDate));
        }

        public List<Game> GetGames()
        {
            return games;
        }
    }
}
