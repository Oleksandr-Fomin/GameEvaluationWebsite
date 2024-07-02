using System.Security.Claims;
using GameEvaluationProject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using WebApp.Pages;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestGetGamesFromDB()
        {
           
            var dbHelper = new DBHelper();
            var expectedGames = new List<Game> { new Game(1, "Game1", "Description1", "Image1", "ReleaseDate1"), new Game(2, "Game2", "Description2", "Image2", "ReleaseDate2") };

           
            var actualGames = dbHelper.GetGamesFromDB();

            
            Assert.AreEqual(expectedGames.Count, actualGames.Count);
            for (int i = 0; i < expectedGames.Count; i++)
            {
                Assert.AreEqual(expectedGames[i].getTitle(), actualGames[i].getTitle());
                Assert.AreEqual(expectedGames[i].getDescription(), actualGames[i].getDescription());
                Assert.AreEqual(expectedGames[i].getImage(), actualGames[i].getImage());
                Assert.AreEqual(expectedGames[i].getReleaseDate(), actualGames[i].getReleaseDate());
            }
        }
        

        //[TestMethod]
        //public void TestOnPostValidCredentials()
        //{
            
        //    var loginModel = new LoginModel { userName = "ValidUser", password = "ValidPassword" };

          
        //    loginModel.OnPost();
        //    var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            
        //    Assert.IsNotNull(claimsPrincipal);
        //    Assert.IsTrue(claimsPrincipal.Identity.IsAuthenticated);
        //    Assert.AreEqual(loginModel.userName, claimsPrincipal.Identity.Name);
        //}
    }
}