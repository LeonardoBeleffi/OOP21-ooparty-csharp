using System.Collections;
using System.Collections.Generic;
using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Model
{
    /// <summary>
    /// Abstract implementation of <see cref="IGameModel"/>.
    /// </summary>
    public abstract class GameModelAbstr : IGameModel
    {
        /// <summary>
        /// Builds a <see cref="GameModelAbstr"/>.
        /// </summary>
        /// <param name="players">The list of players.</param>
        public GameModelAbstr(List<IPlayer> players)
        {
            Players = players;
            PlayerEnumerator = Players.GetEnumerator();
        }

        public List<IPlayer> Players { get; protected set; }

        public abstract bool RunGame();

        public IEnumerator PlayerEnumerator { get; protected set; }
    }
}
