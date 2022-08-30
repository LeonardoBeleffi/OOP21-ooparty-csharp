using System.Collections.Generic;
using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Model
{
    /// <summary>
    /// This interface models the game model.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// <c>Players</c> represents the list of players.
        /// </summary>
        List<IPlayer> Players { get; }

        /// <summary>
        /// <c>CurrPlayer</c> represents the current player.
        /// </summary>
        IPlayer CurrPlayer { get; }

        /// <summary>
        /// This method runs the game as long as there are turns to do.
        /// </summary>
        /// <returns>True if there is another turn to play</returns>
        bool RunGame();
    }
}
