using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationLibrary;
using Logic;

namespace Logic.Entities
{
    public interface IGame
    {
        string GetTitle();
        string GetDescription();
        string GetImage();
        string GetReleaseDate();
        string GetGenres();
        int GetId();
    }

    public class Game : IGame
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ReleaseDate { get; set; }
        public int GameId { get; set; }
        public double AverageScore { get; set; }
        public string Genre { get; set; }

        public Game(string title, string description, string imageURL, string releaseDate, string genre)
        {
            this.Title = title;
            this.Description = description;
            this.ImageURL = imageURL;
            this.ReleaseDate = releaseDate;
            this.Genre = genre;
        }

        public override string ToString()
        {
            return GetTitle();
        }

        public string GetGenres()
        {
            return Genre;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }

        public string GetImage()
        {
            return ImageURL;
        }

        public string GetReleaseDate()
        {
            return ReleaseDate;
        }

        public int GetId()
        {
            return GameId;
        }

        public void SetId(int GameId)
        {
            this.GameId = GameId;
        }
    }
}