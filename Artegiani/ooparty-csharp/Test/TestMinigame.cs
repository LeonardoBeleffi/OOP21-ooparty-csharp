using System.Collections.Generic;
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
            Assert.IsNull(m.PlayerEnumerator.Current);
            m.RunGame();
            Assert.AreEqual(players[0], m.PlayerEnumerator.Current);
            for (int i = 0; i < players.Count; i++)
            {
                m.RunGame();
            }
            Assert.AreEqual(players[^1], m.PlayerEnumerator.Current);
        }

        /*[Test]
        public void TestScoreMapper()
        {
            IMinigameModel m = new MinigameModel(players, new DiceModelNoRepeatImpl());
            players.forEach(p->m.scoreMapper(p, scores.get(players.indexOf(p))));
            final Map<Player, Integer> correctMap = Map.of(new PlayerImpl("Luca"), 4, new PlayerImpl("Giovanni"), 7,
                    new PlayerImpl("Lorenzo"), 5, new PlayerImpl("Marco"), 2);
            assertEquals(correctMap, m.getPlayersClassification());
        }

        [Test]
        public void TestSortPlayerByScore()
        {
            final MinigameModel m = new MinigameModelImpl(players, new DiceModelNoRepeatImpl());
            assertEquals(this.players, m.getGameResults());
            players.forEach(p->m.scoreMapper(p, scores.get(players.indexOf(p))));
            final List<Player> orderedList = List.of(new PlayerImpl("Giovanni"), new PlayerImpl("Lorenzo"),
                    new PlayerImpl("Luca"), new PlayerImpl("Marco"));
            m.runGame();
            assertEquals(orderedList, m.getGameResults());
        }

        [Test]
        public void TestSortPlayerByScoreWithDraws()
        {
            final MinigameModel m = new MinigameModelImpl(players, new DiceModelNoRepeatImpl());
            players.forEach(p->m.scoreMapper(p, scoresDupl.get(players.indexOf(p))));
            List<List<Player>> orderedDuplList = List.of(
                    List.of(new PlayerImpl("Giovanni"), new PlayerImpl("Marco"), new PlayerImpl("Luca"),
                            new PlayerImpl("Lorenzo")),
                    List.of(new PlayerImpl("Giovanni"), new PlayerImpl("Marco"), new PlayerImpl("Lorenzo"),
                            new PlayerImpl("Luca")));
            m.runGame();
            assertTrue(orderedDuplList.contains(m.getGameResults()));
        }*/
    }
}
