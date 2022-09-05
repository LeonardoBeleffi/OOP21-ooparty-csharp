
using ooparty_csharp.Game.Player;
using ooparty_csharp.Utils.Exceptions;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// Implementation of <see cref="IGameMap"/>.
    /// </summary>
    public class GameMap : IGameMap
    {
        public List<IGameMapSquare> Squares { get; }
        /// <summary>
        /// Number of coins required to buy a star.
        /// </summary>
        public const int CoinsToBuyStar = 30;

        public IGameMapSquare GetPlayerPosition(IPlayer p)
        {
            foreach (IGameMapSquare b in this.Squares)
            {
                if (b.GetPlayers().Contains(p))
                {
                    return b;
                }
            }
            throw new PlayerNotFoundException("Player not found in the game map");
        }

        public void InitializePlayers(List<IPlayer> players)
        {
            IGameMapSquare firstGameMapSquare = this.Squares[0];
            foreach (IPlayer p in players)
            {
                if (!this.IsPlayerAlreadyInGameMap(p))
                {
                    firstGameMapSquare.AddPlayer(p);
                }
            }
        }

        private bool IsPlayerAlreadyInGameMap (IPlayer p)
        {
            foreach (IGameMapSquare b in this.Squares)
            {
                if (b.GetPlayers().Contains(p))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
