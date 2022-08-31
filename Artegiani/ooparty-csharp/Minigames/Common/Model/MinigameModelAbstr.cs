using System.Collections.Generic;
using System.Linq;
using ooparty_csharp.Game.Dice;
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
        private readonly DiceModelNoRepeat dice;

        /// <summary>
        /// Builds a <see cref="MinigameModelAbstr"/>.
        /// </summary>
        /// <param name="players">The list of players.</param>
        /// <param name="dice">The dice to use for the playoff.</param>
        public MinigameModelAbstr(List<IPlayer> players, DiceModelNoRepeat dice) : base(players)
        {
            this.dice = dice;
        }

        public List<IPlayer> GameResults { get; private set; }

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

        /// <summary>
        /// This method sets <c>GameResults</c>.
        /// </summary>
        protected void SetGameResults()
        {
            GameResults = Playoff(GroupPlayersByScore());
        }

        private List<IPlayer> Playoff(Dictionary<int, List<IPlayer>> scoreGroups)
        {
            foreach (var e in scoreGroups)
            {
                List<IPlayer> players = e.Value;
                if (players.Count > 1)
                {
                    Dictionary<IPlayer, int> sorted = new Dictionary<IPlayer, int>();
                    players.ForEach(player =>
                    {
                        dice.RollDice(player);
                        sorted.Add(player, dice.LastResult.Value);
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
