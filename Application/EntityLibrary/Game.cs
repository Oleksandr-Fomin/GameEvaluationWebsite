using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace GameEvaluationProject
{
    public interface IGame
    {
        string getTitle();
        string getDescription();
        string getImage();
        string getReleaseDate();

        int getId();
    }

    public class Game : IGame
    {
        public string title;
        public string description;
        public string imageURL;
        public string releaseDate;
        public int gameId;
        public double AverageScore { get; set; }
        public string Genre { get; set; }

        public Game(string title, string description, string imageURL, string releaseDate, string Genre)
        {
            this.title = title;
            this.description = description;
            this.imageURL = imageURL;
            this.releaseDate = releaseDate;
            this.Genre = Genre;
        }

        public override string ToString()
        {
            return getTitle();
        }
        public string getGenres()
        { return Genre; }
        public string getTitle()
        {
            return title;
        }

        public string getDescription()
        {
            return description;
        }

        public string getImage()
        {
            return imageURL;
        }

        public string getReleaseDate()
        {
            return releaseDate;
        }

        public int getId()
        {
            return gameId;
        }

        public void setId(int gameId)
        {
            this.gameId = gameId;
        }
    }
}
