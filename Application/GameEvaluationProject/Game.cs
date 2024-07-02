using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace GameEvaluationProject
{
    public class Game
    {
        public string title;
        public string description;
        public string image;
        public string releaseDate;
        

        public Game(string title, string description, string image, string releaseDate)
        {
            this.title = title;
            this.description = description;
            this.image = image;
            this.releaseDate = releaseDate;
        }

       

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
            return image;
        }

        public string getReleaseDate()
        {
            return releaseDate;
        }
    }
}
