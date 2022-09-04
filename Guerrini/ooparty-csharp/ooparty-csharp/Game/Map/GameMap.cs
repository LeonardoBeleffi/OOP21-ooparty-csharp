
using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Map
{
    public class GameMap : IGameMap
    {
        private List<IGameMapSquare> _squares;
        public const int CoinsToBuyStar = 30;
        
        /// <summary>
        /// Builder for <see cref="IGameMap"/>.
        /// </summary>
        public GameMap()
        {

        }

        public List<IGameMapSquare> GetSquares()
        {
            throw new System.NotImplementedException();
        }

        public IGameMapSquare GetPlayerPosition(IPlayer p)
        {
            throw new System.NotImplementedException();
        }

        public void InitializePlayers(List<IPlayer> players)
        {
            throw new System.NotImplementedException();
        }
    }
}
