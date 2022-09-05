using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Dice
{
    /// <summary>
    /// This interface models the dice model.
    /// </summary>
    public interface IDiceModel
    {
        /// <summary>
        /// <c>LastResult</c> contains the result of the last roll, if the dice was ever rolled.
        /// </summary>
        int? LastResult { get; }

        /// <summary>
        /// <c>Results</c> is a list containing all of the results of the dice,
        /// along with the player who rolled them.
        /// </summary>
        List<KeyValuePair<IPlayer, int>> Results { get; }

        /// <summary>
        /// This method makes the dice roll and generate a result.
        /// </summary>
        /// <param name="player">The player who's rolling the dice.</param>
        /// <returns>The result of the roll.</returns>
        int RollDice(IPlayer player);

        /// <summary>
        /// This method resets the dice to its base state,
        /// deleting all of the past results.
        /// </summary>
        void Reset();

        /// <summary>
        /// This method calculates the sum of all of the previous results.
        /// </summary>
        /// <returns>The sum of all of the results.</returns>
        int GetTotal();
    }
}
