using System.Collections.Generic;
using NUnit.Framework;
using ooparty_csharp.Game.Dice;
using ooparty_csharp.Game.Player;
using ooparty_csharp.Minigames.Mastermind;

namespace ooparty_csharp.Test
{
    /// <summary>
    /// Test class for Mastermind model.
    /// </summary>
    [TestFixture]
    public class TestMastermind
    {
        private List<IPlayer> players;

        [SetUp]
        public void SetUp()
        {
            players = new List<IPlayer>()
            {
                new Player("Luca"),
                new Player("Giovanni"),
                new Player("Lorenzo"),
                new Player("Marco")
            };
        }

        [Test]
        public void TestInput()
        {
            IMastermindModel m = new MastermindModel(players, new DiceModelNoRepeat())
            {
                MaxAttempts = 10
            };
            m.RunGame();
            m.DoAttempt("");
            m.DoAttempt("1232");
            m.DoAttempt("12e3");
            m.DoAttempt("wasd");
            m.DoAttempt("123456789");
            Assert.AreEqual(0, m.NAttempts);
            m.DoAttempt("1234");
            Assert.AreEqual(1, m.NAttempts);
        }

        [Test]
        public void TestWin()
        {
            IMastermindModel m = new MastermindModel(players, new DiceModelNoRepeat())
            {
                MaxAttempts = 10
            };
            m.RunGame();
            m.DoAttempt(m.Solution);
            Assert.IsTrue(m.Win);
        }

        [Test]
        public void TestLose()
        {
            IMastermindModel m = new MastermindModel(players, new DiceModelNoRepeat())
            {
                MaxAttempts = 1
            };
            m.RunGame();
            char[] attemptDigits = m.Solution.ToCharArray();
            char temp = attemptDigits[3];
            attemptDigits[3] = attemptDigits[0];
            attemptDigits[0] = temp;
            string attempt = "" + attemptDigits[0] + attemptDigits[1] + attemptDigits[2] + attemptDigits[3];
            m.DoAttempt(attempt);
            Assert.IsTrue(m.Lose);
        }
    }
}
