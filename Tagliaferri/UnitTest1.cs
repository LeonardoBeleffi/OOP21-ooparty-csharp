using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace OOP_csharp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirstSquare()
        {
            var factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();
            Assert.AreEqual(typeof(GameMapSquareImpl), board[0].GetType());
        }

        [TestMethod]
        public void TestSize()
        {
            IGameBoardFactory factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();
            Assert.AreEqual(factory.Size, board.Count);
        }

        [TestMethod]
        public void TestStarsCount()
        {
            IGameBoardFactory factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();

            var starsCount = board
                .Where(s => s.GetType().Equals(typeof(StarGameMapSquare)))
                .Select(s => 1)
                .Aggregate(0, (r, e) => r + e);


            Assert.AreEqual(
                SimpleGameBoardFactory.GetSquareTypeMaxOccurrences().Where(s => s.Item2.Equals(typeof(StarGameMapSquare))).First().Item3,
                starsCount);

        }

        [TestMethod]
        public void TestCoinsCount()
        {
            IGameBoardFactory factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();

            var coinsCount = board
                .Where(s => s.GetType().Equals(typeof(CoinsGameMapSquare)))
                .Select(s => 1)
                .Aggregate(0, (r, e) => r + e);

            Assert.AreEqual(
                SimpleGameBoardFactory.GetSquareTypeMaxOccurrences().Where(s => s.Item2.Equals(typeof(CoinsGameMapSquare))).First().Item3,
                coinsCount);

        }

        [TestMethod]
        public void TestPowerUpCount()
        {
            IGameBoardFactory factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();

            var powerUpCount = board
                .Where(s => s.GetType().Equals(typeof(PowerUpGameMapSquare)))
                .Select(s => 1)
                .Aggregate(0, (r, e) => r + e);

            Assert.AreEqual(
                SimpleGameBoardFactory.GetSquareTypeMaxOccurrences().Where(s => s.Item2.Equals(typeof(PowerUpGameMapSquare))).First().Item3,
                powerUpCount);

        }

        [TestMethod]
        public void TestDamageCount()
        {
            IGameBoardFactory factory = new SimpleGameBoardFactory();
            var board = factory.CreateGameBoard();

            var damageCount = board
                .Where(s => s.GetType().Equals(typeof(DamageGameMapSquare)))
                .Select(s => 1)
                .Aggregate(0, (r, e) => r + e);

            Assert.AreEqual(
                SimpleGameBoardFactory.GetSquareTypeMaxOccurrences().Where(s => s.Item2.Equals(typeof(DamageGameMapSquare))).First().Item3,
                damageCount);

        }
    }
}
