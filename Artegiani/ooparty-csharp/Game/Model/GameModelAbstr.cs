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
        public GameModelAbstr(List<IPlayer> players)
        {
            Players = players;
            PlayerEnumerator = Players.GetEnumerator();
            CurrPlayer = null;
        }

        public List<IPlayer> Players { get; private set; }

        public IPlayer CurrPlayer
        {
            get => CurrPlayer;
            private set => CurrPlayer = (IPlayer)PlayerEnumerator.Current;
        }

        public abstract bool RunGame();

        /// <summary>
        /// <c>PlayerEnumerator</c> represents the enumerator of the list of players.
        /// </summary>
        protected IEnumerator PlayerEnumerator { set; get; }
    }
}
