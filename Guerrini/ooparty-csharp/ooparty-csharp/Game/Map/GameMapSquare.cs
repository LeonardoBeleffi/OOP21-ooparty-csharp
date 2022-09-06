using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// The implementation of a generic <see cref="IGameMapSquare"/>.
    /// </summary>
    public class GameMapSquare : IGameMapSquare
    {
        public ISet<IPlayer> Players { get; }

        /// <summary>
        /// Maximum number of coins that can be found on a coin square.
        /// </summary>
        public const int MaxCoins = 20;

        /// <summary>
        /// Maximum number of damage that can be taken from a damage square.
        /// </summary>
        public const int MaxDamage = Player.Player.MaxLife / 2;

        /// <summary>
        /// Builder for <see cref="GameMapSquare"/>.
        /// </summary>
        public GameMapSquare()
        {
            this.Players = new HashSet<IPlayer>();
        }

        public void AddPlayer(IPlayer p) => Players.Add(p);

        public bool IsCoinsGameMapSquare()
        {
            return false;
        }

        public bool IsDamageGameMapSquare()
        {
            return false;
        }

        public bool IsPowerUpGameMapSquare()
        {
            return false;
        }

        public bool IsStarGameMapSquare()
        {
            return false;
        }

        public void MakeSpecialAction(IPlayer p)
        {
        }

        public void RemovePlayer(IPlayer p) => this.Players.Remove(p);
    }
}
