using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ooparty_csharp.Game.Dice;
using ooparty_csharp.Game.Player;
using ooparty_csharp.Minigames.Common.Model;

namespace ooparty_csharp.Test
{
    /// <summary>
    /// Test class for a generic minigame model.
    /// </summary>
    [TestFixture]
    public class TestMinigame
    {
        private class MinigameModel : MinigameModelAbstr
        {
            public MinigameModel(List<IPlayer> players, DiceModelNoRepeat dice) : base(players, dice)
            {
            }

            public override bool RunGame()
            {
                PlayerEnumerator.MoveNext();
                SetGameResults();
                return false;
            }
        }

        private List<IPlayer> players;
        private List<int> scores;
        private List<int> scoresDupl;

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
            scores = new List<int>() { 4, 7, 5, 2 };
            scoresDupl = new List<int>() { 2, 7, 2, 5 };
        }

        [Test]
        public void TestPlayerTurns()
        {
            IMinigameModel m = new MinigameModel(players, new DiceModelNoRepeat());
            Assert.That(() => m.PlayerEnumerator.Current, Throws.InvalidOperationException);
            m.RunGame();
            Assert.AreEqual(players[0], m.PlayerEnumerator.Current);
            for (int i = 0; i < players.Count; i++)
            {
                m.RunGame();
            }
            Assert.IsFalse(m.PlayerEnumerator.MoveNext());
        }

        [Test]
        public void TestScoreMapper()
        {
            IMinigameModel m = new MinigameModel(players, new DiceModelNoRepeat());
            players.ForEach(p => m.ScoreMapper(p, scores[players.IndexOf(p)]));
            var correctMap = new Dictionary<IPlayer, int>()
            {
                { new Player("Luca"), 4 },
                { new Player("Giovanni"), 7 },
                { new Player("Lorenzo"), 5 },
                { new Player("Marco"), 2 }
            };
            CollectionAssert.AreEqual(correctMap, m.PlayersClassification);
        }

        [Test]
        public void TestSortPlayerByScore()
        {
            IMinigameModel m = new MinigameModel(players, new DiceModelNoRepeat());
            Assert.AreEqual(players, m.GameResults);
            players.ForEach(p => m.ScoreMapper(p, scores[players.IndexOf(p)]));
            var orderedList = new List<IPlayer>()
            {
                new Player("Giovanni"),
                new Player("Lorenzo"),
                new Player("Luca"),
                new Player("Marco")
            };
            m.RunGame();
            CollectionAssert.AreEqual(orderedList, m.GameResults);
        }

        [Test]
        public void TestSortPlayerByScoreWithDraws()
        {
            IMinigameModel m = new MinigameModel(players, new DiceModelNoRepeat());
            players.ForEach(p => m.ScoreMapper(p, scoresDupl[players.IndexOf(p)]));
            var orderedDuplList = new List<List<IPlayer>>()
            {
                    new List<IPlayer>
                    {
                        new Player("Giovanni"),
                        new Player("Marco"),
                        new Player("Luca"),
                        new Player("Lorenzo")
                    },
                    new List<IPlayer>
                    {
                        new Player("Giovanni"),
                        new Player("Marco"),
                        new Player("Lorenzo"),
                        new Player("Luca")
                    }
            };
            m.RunGame();
            Assert.IsTrue(orderedDuplList.Any(l => l.SequenceEqual(m.GameResults)));
        }
    }
}
