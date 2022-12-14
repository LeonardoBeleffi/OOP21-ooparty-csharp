using System;
using ooparty_csharp.Minigames.Common.Model;

namespace ooparty_csharp.Minigames.Mastermind
{
    /// <summary>
    /// This interface models the mastermind model. Specializtion of
    /// <see cref="IMinigameModel"/>.
    /// </summary>
    public interface IMastermindModel : IMinigameModel
    {
        /// <summary>
        /// <c>Win</c> is true if the current player has guessed the 4-digit number.
        /// </summary>
        bool Win { get; }

        /// <summary>
        /// <c>Lose</c> is true if the current player hasn't guessed the 4-digit
        /// number and the attempts are ended.
        /// </summary>
        bool Lose { get; }

        /// <summary>
        /// <c>NAttempts</c> represents the number of attempts.
        /// </summary>
        int NAttempts { get; }

        /// <summary>
        /// <c>Solution</c> represents the number to guess.
        /// </summary>
        string Solution { get; }

        /// <summary>
        /// <c>MaxAttempts</c> represents the maximum number of attempts.
        /// </summary>
        int MaxAttempts { get; set; }

        /**
         * This method controls the attempt of the player.
         * 
         * @param attempt the player attempt
         * @return the attempt string if the attempt is valid, empty string otherwise
         */
        /// <summary>
        /// This method checks the attempt of the player.
        /// </summary>
        /// <param name="attempt">The player's attempt.</param>
        /// <returns>The attempt string if the attempt is valid, empty string otherwise.</returns>
        string DoAttempt(string attempt);
    }
}
