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
            return new ScoreServiceFile();
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
}
