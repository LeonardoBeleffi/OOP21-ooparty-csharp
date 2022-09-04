using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// Interface for the game map.
    /// </summary>
    public interface IGameMap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the list of the map's squares</returns>
        List<IGameMapSquare> GetSquares();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">the <see cref="IPlayer"/> you want to know the position</param>
        /// <returns>the player p's position</returns>
        IGameMapSquare GetPlayerPosition(IPlayer p);

        /// <summary>
        /// Puts all the players in the starting square if they are not already on the map.
        /// </summary>
        /// <param name="players">the list of the players to be put in the starting square</param>
        void InitializePlayers(List<IPlayer> players);
    }
}
