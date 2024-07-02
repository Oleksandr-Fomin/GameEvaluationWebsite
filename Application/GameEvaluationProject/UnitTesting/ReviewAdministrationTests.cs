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
    public class ReviewAdministrationTests
    {
        private List<Review> reviews = new List<Review>()
        {
            new Review(1, 1, "User1", "John", 8, "Good game!", new DateTime(2023, 2, 17)),
            new Review(2, 2, "User2", "Dmitriy", 10, "Excellent game!", new DateTime(2023, 1, 11)),
            new Review(3, 3, "User1", "John", 2, "Not so good", new DateTime(2023, 3, 21)),
        };

        [Fact]
        public void GetReviewsByGameId_ShouldReturnCorrectReviews()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetReviewsByGameId(1)).Returns(new List<Review>()
            {
                new Review(1, 1, "User1", "John", 8, "Good game!", new DateTime(2023, 2, 17))
            });

            var reviewAdmin = new ReviewAdministration(mockDbHelper.Object);

            var reviews = reviewAdmin.GetReviewsByGameId(1);

            Assert.Single(reviews);
            Assert.Equal(1, reviews[0].gameId);
        }

        [Fact]
        public void AddReview_ShouldAddNewReview()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            var reviewAdmin = new ReviewAdministration(mockDbHelper.Object);

            var result = reviewAdmin.AddReview(1, "User1", 8, "Good game!");

            mockDbHelper.Verify(db => db.AddReview(1, "User1", 8, "Good game!"), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void GetAverageScore_ShouldReturnCorrectAverageScore()
        {
            var mockDbHelper = new Mock<IDBHelper>();
            mockDbHelper.Setup(db => db.GetAverageScore(1)).Returns(8.0);
            var reviewAdmin = new ReviewAdministration(mockDbHelper.Object);

            var averageScore = reviewAdmin.GetAverageScore(1);

            Assert.Equal(8.0, averageScore);
        }
    }
}
