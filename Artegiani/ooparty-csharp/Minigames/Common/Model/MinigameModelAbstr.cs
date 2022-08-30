using System.Collections.Generic;
using System.Linq;
using ooparty_csharp.Game.Model;
using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Minigames.Common.Model
{
    /// <summary>
    /// Implementation of <see cref="IMinigameModel"/> and specialization of
    /// <see cref="IGameModel"/>.
    /// </summary>
    public abstract class MinigameModelAbstr : GameModelAbstr, IMinigameModel
    {
        public MinigameModelAbstr(List<IPlayer> players) : base(players)
        {
            //dice model no repeat
        }

        public List<IPlayer> GameResults
        {
            get => GameResults;
            protected set => Playoff(GroupPlayersByScore());
        }

        public int Score
        {
            get => PlayersClassification.GetValueOrDefault(PlayerEnumerator.Current as IPlayer, 0);
            protected set => ScoreMapper(PlayerEnumerator.Current as IPlayer, value);
        }

        public Dictionary<IPlayer, int> PlayersClassification { get; }

        public void ScoreMapper(IPlayer player, int score)
        {
            PlayersClassification.Add(player, score);
        }

        private List<IPlayer> Playoff(Dictionary<int, List<IPlayer>> scoreGroups)
        {
            foreach (var e in scoreGroups)
            {
                List<IPlayer> players = e.Value;
                if (players.Count > 1)
                {
                    Dictionary<IPlayer, int> sorted = new();
                    players.ForEach(player =>
                    {
                        //this.dice.rollDice(player);
                        sorted.Add(player, 1/*this.dice.getLastResult().get()*/);
                    });
                    players = sorted.OrderByDescending(el => el.Value).Select(el => el.Key).ToList();
                    scoreGroups[e.Key] = players;
                }
            }
            return scoreGroups.Values.SelectMany(e => e).ToList();
        }

        private Dictionary<int, List<IPlayer>> GroupPlayersByScore()
        {
            return (Dictionary<int, List<IPlayer>>)PlayersClassification.OrderByDescending(e => e.Value)
                .GroupBy(e => e.Key)
                .Select(grp => grp.ToList());
        }
    }
}
