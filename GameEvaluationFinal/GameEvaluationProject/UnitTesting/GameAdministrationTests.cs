using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationLibrary;
using Logic.Entities;
using Logic;
using Moq;
using Logic.Filtering_and_Sorting;

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
        public void GetAllGamesSorted_ShouldThrowException_WhenFilterMatchThrowsException()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(new List<Game> { new Game("Dota 2", "description", "imageURL", "13.10.2020", "action") });

            var mockFilter = new Mock<IFiltering<Game>>();
            mockFilter.Setup(f => f.Match(It.IsAny<Game>())).Throws<Exception>();

            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            Assert.Throws<Exception>(() => gameAdmin.GetAllGamesSorted(mockFilter.Object));
        }

        [Fact]
        public void GetGamesSortedByAverageScore_ShouldReturnEmptyList_WhenGetGamesFromDBReturnsNull()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(value: null);

            var gameAdmin = new GameAdministration(mockDbHelper.Object);
            var games = gameAdmin.GetGamesSortedByAverageScore();

            Assert.Empty(games); 
        }

        [Fact]
        public void GetGamesSortedByAverageScore_ShouldThrowException_WhenGetAverageScoreThrowsException()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(new List<Game> { new Game("Dota 2", "description", "imageURL", "13.10.2020", "action") });
            mockDbHelper.Setup(db => db.GetAverageScore(It.IsAny<int>())).Throws<Exception>();

            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            Assert.Throws<Exception>(() => gameAdmin.GetGamesSortedByAverageScore());
        }

        [Fact]
        public void DeleteGame_ShouldThrowExceptionWhenGameDoesntExist()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            mockDbHelper.Setup(db => db.DeleteGame(It.IsAny<int>())).Throws<Exception>();

            Assert.Throws<Exception>(() => gameAdmin.DeleteGame(999));
        }

        [Fact]
        public void AddGame_ShouldReturnFalseWhenGameIsNull()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var result = gameAdmin.AddGame(null);

            Assert.False(result);
        }

        [Fact]
        public void GetAllGames_ShouldReturnAllGames()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var result = gameAdmin.GetAllGames();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetGameById_ShouldReturnCorrectGame()
        {
            
            var mockDbHelper = new Mock<IGameDBHelper>();
            var expectedGame = new Game("Title", "Description", "ImageURL", "ReleaseDate", "Genre");
            expectedGame.SetId(1);
            mockDbHelper.Setup(db => db.GetGameById(1)).Returns(expectedGame);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            
            var actualGame = gameAdmin.GetGameById(1);

            
            Assert.NotNull(actualGame);  
            Assert.Equal(expectedGame.GetId(), actualGame.GetId());
        }

        [Fact]
        public void AddGame_ShouldAddNewGame()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var newGame = new Game("Sea of thieves", "description3", "imageURL3", "11.08.2019", "action");

            gameAdmin.AddGame(newGame);

            mockDbHelper.Verify(db => db.ExportGames(It.IsAny<List<Game>>()), Times.Once);
        }

        [Fact]
        public void GetNextGameId_ShouldReturnNextGameId()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetNextGameId()).Returns(games.Count + 1);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var nextGameId = gameAdmin.GetNextGameId();

            Assert.Equal(3, nextGameId);
        }

        [Fact]
        public void GetGamesSortedByAverageScore_ShouldReturnSortedGames()
        {
            var mockDbHelper = new Mock<IGameDBHelper>();
            mockDbHelper.Setup(db => db.GetGamesFromDB()).Returns(games);
            mockDbHelper.Setup(db => db.GetAverageScore(It.IsAny<int>())).Returns((int id) => games.FirstOrDefault(g => g.GameId == id).AverageScore);
            var gameAdmin = new GameAdministration(mockDbHelper.Object);

            var sortedGames = gameAdmin.GetGamesSortedByAverageScore();

            Assert.Equal(2, sortedGames[0].GameId);
        }
    }
    
}

