using LightsOff.Core;
using LightsOffCore.Core;
using LightsOffCore.Entity;
using LightsOffCore.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LightsOffTest
{
    [TestClass]
    public class ScoreServiceTest
    {

        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });

            Assert.AreEqual(1, service.GetTopScores().Count);
            Assert.AreEqual("Jaro", service.GetTopScores()[0].Player);
            Assert.AreEqual(100, service.GetTopScores()[0].Points);
        }

        [TestMethod]
        public void AddTest3()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Peter", Points = 200, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jozo", Points = 50, PlayedAt = DateTime.Now });

            Assert.AreEqual(3, service.GetTopScores().Count);

            Assert.AreEqual("Peter", service.GetTopScores()[0].Player);
            Assert.AreEqual(200, service.GetTopScores()[0].Points);

            Assert.AreEqual("Jaro", service.GetTopScores()[1].Player);
            Assert.AreEqual(100, service.GetTopScores()[1].Points);

            Assert.AreEqual("Jozo", service.GetTopScores()[2].Player);
            Assert.AreEqual(50, service.GetTopScores()[2].Points);
        }

        [TestMethod]
        public void AddTest5()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "Zuzka", Points = 20, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Anca", Points = 10, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Peter", Points = 200, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jozo", Points = 50, PlayedAt = DateTime.Now });

            Assert.AreEqual(5, service.GetTopScores().Count);

            Assert.AreEqual("Peter", service.GetTopScores()[0].Player);
            Assert.AreEqual(200, service.GetTopScores()[0].Points);

            Assert.AreEqual("Jaro", service.GetTopScores()[1].Player);
            Assert.AreEqual(100, service.GetTopScores()[1].Points);

            Assert.AreEqual("Jozo", service.GetTopScores()[2].Player);
            Assert.AreEqual(50, service.GetTopScores()[2].Points);

            Assert.AreEqual("Zuzka", service.GetTopScores()[3].Player);
            Assert.AreEqual(20, service.GetTopScores()[3].Points);

            Assert.AreEqual("Anca", service.GetTopScores()[4].Player);
            Assert.AreEqual(10, service.GetTopScores()[4].Points);
        }

        [TestMethod]
        public void AddTest11()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "Zuzka", Points = 20, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Anca", Points = 10, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Peter", Points = 200, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jozo", Points = 50, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Daniel", Points = 300, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Egor", Points = 220, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Vialeta", Points = 290, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Misha", Points = 110, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Sasha", Points = 40, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Eugen", Points = 500, PlayedAt = DateTime.Now });

            Assert.AreEqual(10, service.GetTopScores().Count);

            Assert.AreEqual("Eugen", service.GetTopScores()[0].Player);
            Assert.AreEqual(500, service.GetTopScores()[0].Points);

            Assert.AreEqual("Daniel", service.GetTopScores()[1].Player);
            Assert.AreEqual(300, service.GetTopScores()[1].Points);

            Assert.AreEqual("Vialeta", service.GetTopScores()[2].Player);
            Assert.AreEqual(290, service.GetTopScores()[2].Points);

            Assert.AreEqual("Egor", service.GetTopScores()[3].Player);
            Assert.AreEqual(220, service.GetTopScores()[3].Points);

            Assert.AreEqual("Peter", service.GetTopScores()[4].Player);
            Assert.AreEqual(200, service.GetTopScores()[4].Points);

            Assert.AreEqual("Misha", service.GetTopScores()[5].Player);
            Assert.AreEqual(110, service.GetTopScores()[5].Points);

            Assert.AreEqual("Jaro", service.GetTopScores()[6].Player);
            Assert.AreEqual(100, service.GetTopScores()[6].Points);

            Assert.AreEqual("Jozo", service.GetTopScores()[7].Player);
            Assert.AreEqual(50, service.GetTopScores()[7].Points);

            Assert.AreEqual("Sasha", service.GetTopScores()[8].Player);
            Assert.AreEqual(40, service.GetTopScores()[8].Points);

            Assert.AreEqual("Zuzka", service.GetTopScores()[9].Player);
            Assert.AreEqual(20, service.GetTopScores()[9].Points);
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "Jaro", Points = 100, PlayedAt = DateTime.Now });

            service.ResetScore();
            Assert.AreEqual(0, service.GetTopScores().Count);
        }

        private IScoreService CreateService()
        {
            var service = new ScoreServiceEF();
            service.ResetScore();

            return service;
        }

    }

    [TestClass]
    public class ChangeLightsTest
    {
        [TestMethod]
        public void UpperLeftCorner()
        {
            int x = 0;
            int y = 0;
            Field _field = new Field(5, 5);
            ChangeLights changeLights = new ChangeLights(_field);
            int result = 1;

            try
            {
                changeLights.Toggle(x, y);
            }
            catch (IndexOutOfRangeException indexOutOfMap)
            {
                result = 0;
            }

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpperRightCorner()
        {
            int x = 4;
            int y = 0;
            Field _field = new Field(5, 5);
            ChangeLights changeLights = new ChangeLights(_field);
            int result = 1;

            try
            {
                changeLights.Toggle(x, y);
            }
            catch (IndexOutOfRangeException indexOutOfMap)
            {
                result = 0;
            }

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LowerRightCorner()
        {
            int x = 4;
            int y = 4;
            Field _field = new Field(5, 5);
            ChangeLights changeLights = new ChangeLights(_field);
            int result = 1;

            try
            {
                changeLights.Toggle(x, y);
            }
            catch (IndexOutOfRangeException indexOutOfMap)
            {
                result = 0;
            }

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LowerLeftCorner()
        {
            int x = 0;
            int y = 4;
            Field _field = new Field(5, 5);
            ChangeLights changeLights = new ChangeLights(_field);
            int result = 1;

            try
            {
                changeLights.Toggle(x, y);
            }
            catch (IndexOutOfRangeException indexOutOfMap)
            {
                result = 0;
            }

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CenterOfMap()
        {
            int x = 2;
            int y = 2;
            Field _field = new Field(5, 5);
            ChangeLights changeLights = new ChangeLights(_field);
            int result = 1;

            try
            {
                changeLights.Toggle(x, y);
            }
            catch (IndexOutOfRangeException indexOutOfMap)
            {
                result = 0;
            }

            Assert.AreEqual(1, result);
        }
    }

    [TestClass]
    public class FinishTest
    {
        [TestMethod]
        public void AllLightsOff()
        {
            Field _field = new Field(5, 5);
            TurnOffAllLights(_field);

            Assert.AreEqual(true, _field.IfWin());
        }

        [TestMethod]
        public void NotAllLightsOff()
        {
            Field _field = new Field(5, 5);
            TurnOnAllLights(_field);
            _field[0, 2].Value = false;

            Assert.AreEqual(false, _field.IfWin());
        }

        [TestMethod]
        public void AllLightsOn()
        {
            Field _field = new Field(5, 5);
            TurnOnAllLights(_field);

            Assert.AreEqual(false, _field.IfWin());
        }

        private void TurnOffAllLights(Field field)
        {
            for (var row = 0; row < field.RowCount; row++)
            {
                for (var column = 0; column < field.ColumnCount; column++)
                {
                    field[row, column].Value = false;
                }
            }
        }

        private void TurnOnAllLights(Field field)
        {
            for (var row = 0; row < field.RowCount; row++)
            {
                for (var column = 0; column < field.ColumnCount; column++)
                {
                    field[row, column].Value = true;
                }
            }
        }

    }

    [TestClass]
    public class CommentServiceTest
    {
        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "Jaro", Comments = "1" });

            Assert.AreEqual(1, service.GetComments().Count);

            Assert.AreEqual("Jaro", service.GetComments()[0].Player);
            Assert.AreEqual("1", service.GetComments()[0].Comments);
        }

        [TestMethod]
        public void AddTest3()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "Jaro", Comments = "1" });
            service.AddComment(new Comment { Player = "Peter", Comments = "2" });
            service.AddComment(new Comment { Player = "Jozo", Comments = "3" });

            Assert.AreEqual(3, service.GetComments().Count);

            Assert.AreEqual("Jaro", service.GetComments()[0].Player);
            Assert.AreEqual("1", service.GetComments()[0].Comments);

            Assert.AreEqual("Peter", service.GetComments()[1].Player);
            Assert.AreEqual("2", service.GetComments()[1].Comments);

            Assert.AreEqual("Jozo", service.GetComments()[2].Player);
            Assert.AreEqual("3", service.GetComments()[2].Comments);
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "Jaro", Comments = "Great game!!!"});
            service.AddComment(new Comment { Player = "Jaro", Comments = "Thank you for the game!"});

            service.ResetComment();
            Assert.AreEqual(0, service.GetComments().Count);
        }
        private ICommentService CreateService()
        {
            var service = new CommentServiceEF();
            service.ResetComment();

            return service;
        }
    }

    [TestClass]
    public class RatingServiceTest
    {
        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "Jaro", Ratings = 4 });

            Assert.AreEqual(1, service.GetRating().Count);

            Assert.AreEqual("Jaro", service.GetRating()[0].Player);
            Assert.AreEqual(4, service.GetRating()[0].Ratings);

            Assert.AreEqual(4, service.GetGPA());
        }

        [TestMethod]
        public void AddTest3()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "Jaro", Ratings = 3.3 });
            service.AddRating(new Rating { Player = "Peter", Ratings = 2 });
            service.AddRating(new Rating { Player = "Jozo", Ratings = 1 });

            Assert.AreEqual(3, service.GetRating().Count);

            Assert.AreEqual("Jaro", service.GetRating()[0].Player);
            Assert.AreEqual(3.3, service.GetRating()[0].Ratings);

            Assert.AreEqual("Peter", service.GetRating()[1].Player);
            Assert.AreEqual(2, service.GetRating()[1].Ratings);

            Assert.AreEqual("Jozo", service.GetRating()[2].Player);
            Assert.AreEqual(1, service.GetRating()[2].Ratings);

            Assert.AreEqual(2.1, service.GetGPA());
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "Jaro", Ratings = 3.2 });
            service.AddRating(new Rating { Player = "Jaro", Ratings = 4.7 });

            service.ResetRating();
            Assert.AreEqual(0, service.GetRating().Count);
            Assert.AreEqual(0, service.GetGPA());
        }
        private IRatingService CreateService()
        {
            var service = new RatingServiceEF();
            service.ResetRating();

            return service;
        }
    }
}
