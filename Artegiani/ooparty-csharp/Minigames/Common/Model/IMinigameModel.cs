using System.Collections.Generic;
using ooparty_csharp.Game.Model;
using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Minigames.Common.Model
{
    /// <summary>
    /// This interface models a generic minigame model. Specialization of
    /// <see cref="IGameModel"/>.
    /// </summary>
    public interface IMinigameModel : IGameModel
    {
        /// <summary>
        /// <c>GameResults</c> represents the results of the minigame that are necessary
        /// for points assignment, etc... ordered by their classification in the minigame
        /// with no draws.
        /// </summary>
        List<IPlayer> GameResults { get; }

        /**
         * This method associates a player to his score.
         * 
         * @param player the current {@link game.player.Player}
         * @param score  the score of the player at the minigame
         */
        /// <summary>
        /// This method associates a player to his score.
        /// </summary>
        /// <param name="player">The current <see cref="IPlayer"/>.</param>
        /// <param name="score">The score of the player.</param>
        void ScoreMapper(IPlayer player, int score);

        /// <summary>
        /// <c>Score</c> represents the score of the actual player.
        /// </summary>
        int Score { get; }

        /**
         * Getter for playersClassification.
         * 
         * @return a map with players as keys and their score as values
         */
        /// <summary>
        /// <c>PlayersClassification</c> represents a dictionary with players as
        /// keys and their score as values.
        /// </summary>
        Dictionary<IPlayer, int> PlayersClassification { get; }
    }
}
