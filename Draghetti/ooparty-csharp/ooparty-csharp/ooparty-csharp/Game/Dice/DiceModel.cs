using ooparty_csharp.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ooparty_csharp.Game.Dice
{
    /// <summary>
    /// Implementation of <see cref="IDiceModel"/>
    /// </summary>
    class DiceModel : IDiceModel
    {
        /// <summary>
        /// <c>MAX_RESULT</c> contains the maximum possible result of a roll.
        /// </summary>
        protected const int MAX_RESULT = 6;

        /// <summary>
        /// <c>Rand</c> is the <see cref="Random"/> used to get the random results.
        /// </summary>
        protected Random Rand;

        /// <summary>
        /// Builds a <see cref="DiceModel"/>
        /// </summary>
        public DiceModel()
        {
            Rand = new Random();
            LastResult = null;
            Results = new List<KeyValuePair<IPlayer, int>>();
        }

        public int? LastResult { get; private set; }

        public List<KeyValuePair<IPlayer, int>> Results { get; private set; }

        public int GetTotal()
        {
            return Results.Sum(p => p.Value);
        }

        public void Reset()
        {
            LastResult = null;
            Results = new List<KeyValuePair<IPlayer, int>>();
        }

        public int RollDice(IPlayer player)
        {
            int result = Rand.Next(1, MAX_RESULT);
            SetResult(player, result);
            return result;
        }

        /// <summary>
        /// This method is used to set the last result and update the results list,
        /// after a new result is generated.
        /// </summary>
        /// <param name="player">The player who rolled the dice.</param>
        /// <param name="result">The generated result.</param>
        protected void SetResult(IPlayer player, int result)
        {
            LastResult = result;
            Results.Add(new KeyValuePair<IPlayer, int>(player, result));
        }
    }
}
