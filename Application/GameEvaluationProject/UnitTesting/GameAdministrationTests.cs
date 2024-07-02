using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationLibrary;
using GameEvaluationProject;
using Logic;
using Moq;

namespace UnitTesting
{
    public class GameAdministrationTests
    {
        private List<Game> games = new List<Game>()
        {
            new Game("Dota 2", "description", "imageURL1", "12.02.2012", "Action"),
            new Game("CS:GO", "description2", "imageURL2", "12.03.2013", "Survival")
        };

        [Fact]
        public void GetAllGames_ShouldReturnAllGames()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var result = gameAdmin.GetAllGames();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetGameById_ShouldReturnCorrectGame()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetGameById(It.IsAny<int>())).Returns((int id) => games.FirstOrDefault(g => g.gameId == id));
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var game = gameAdmin.GetGameById(1);

            Assert.Equal(1, game.gameId);
        }

        [Fact]
        public void AddGame_ShouldAddNewGame()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            gameAdmin.AddGame("Sea of thieves", "description3", "imageURL3", "11.08.2019", "action");

            mockDbHelper.Verify(db => db.ExportGames(It.IsAny<List<Game>>()), Times.Once);
        }

        [Fact]
        public void GetNextGameId_ShouldReturnNextGameId()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetNextGameId()).Returns(games.Count + 1);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var nextGameId = gameAdmin.GetNextGameId();

            Assert.Equal(3, nextGameId);
        }

        [Fact]
        public void GetGamesSortedByAverageScore_ShouldReturnSortedGames()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            mockDbHelper.Setup(db => db.GetAverageScore(It.IsAny<int>())).Returns((int id) => games.FirstOrDefault(g => g.gameId == id).AverageScore);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var sortedGames = gameAdmin.GetGamesSortedByAverageScore();

            Assert.Equal(2, sortedGames[0].gameId);
        }
    }
    
}

