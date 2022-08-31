using System;
using System.Linq;
using System.Collections.Generic;
using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Dice
{
    /// <summary>
    /// This class models a dice with no repetitions of results.
    /// </summary>
    public class DiceModelNoRepeat
    {
        private const int MaxResult = 6;
        private readonly Random rand;

        /// <summary>
        /// Builds a <see cref="DiceModelNoRepeat"/>.
        /// </summary>
        public DiceModelNoRepeat()
        {
            rand = new Random();
            LastResult = null;
            Results = new List<KeyValuePair<IPlayer, int>>();
        }

        /// <summary>
        /// <c>LastResult</c> represents the result of the last roll.
        /// </summary>
        public int? LastResult
        {
            get => LastResult;
            private set => LastResult = new int?((int)value);
        }

        /// <summary>
        /// <c>Results</c> represents the list of all previous rolls.
        /// </summary>
        public List<KeyValuePair<IPlayer, int>> Results { get; private set; }

        /// <summary>
        /// <c>Total</c> gets the sum of all previous rolls.
        /// </summary>
        public int Total => Results.Select(e => e.Value).Sum();

        /// <summary>
        /// This method makes the dice roll, generating one random result.
        /// </summary>
        /// <param name="player">The <see cref="IPlayer"/> who's rolling the dice.</param>
        /// <returns>The result of the roll.</returns>
        public int RollDice(IPlayer player)
        {
            if (Results.Count == MaxResult)
            {
                throw new InvalidOperationException("No more results available");
            }
            int result;
            do
            {
                result = rand.Next(1, MaxResult);
            } while (Results.Select(r => r.Value).Contains(result));
            SetResult(player, result);
            return result;
        }

        /// <summary>
        /// This method resets the dice to default values, deleting everything about
        /// the previous rolls.
        /// </summary>
        public void Reset()
        {
            LastResult = null;
            Results.Clear();
        }

        /// <summary>
        /// This method sets a result for a dice roll.
        /// </summary>
        /// <param name="player">The <see cref="IPlayer"/> who rolled the dice.</param>
        /// <param name="result">The result of the dice roll.</param>
        private void SetResult(IPlayer player, int result)
        {
            LastResult = new int?(result);
            Results.Add(new KeyValuePair<IPlayer, int>(player, result));
        }
    }
}
