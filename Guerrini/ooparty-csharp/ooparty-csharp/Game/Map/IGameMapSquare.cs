using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Map
{
    public interface IGameMapSquare
    {
        /// <summary>
        /// Returns the set with the list of the player on this square.
        /// </summary>
        /// <returns>a set with the list of the players on this square</returns>
        ISet<IPlayer> GetPlayers();

        /// <summary>
        /// Adds a player in this square (he is located in this square).
        /// </summary>
        /// <param name="p">the player to be added</param>
        void AddPlayer(IPlayer p);

        /// <summary>
        /// Removes a player from this square (he is no longer in this square).
        /// </summary>
        /// <param name="p">the player to be removed</param>
        void RemovePlayer(IPlayer p);

        /// <summary>
        /// Makes the special action of the special square. Every special square will implement this method in different ways.
        /// </summary>
        /// <param name="p">the <see cref="IPlayer"/> that will be affected from the special action</param>
        void MakeSpecialAction(IPlayer p);

        /// <summary>
        /// Returns if this is a <see cref="CoinsGameMapSquare"/>
        /// </summary>
        /// <returns>if this is a <see cref="CoinsGameMapSquare"/></returns>
        bool IsCoinsGameMapSquare();

        /// <summary>
        /// Returns if this is a <see cref="StarGameMapSquare"/>
        /// </summary>
        /// <returns>if this is a <see cref="StarGameMapSquare"/></returns>
        bool IsStarGameMapSquare();

        /// <summary>
        /// Returns if this is a <see cref="PowerUpGameMapSquare"/>
        /// </summary>
        /// <returns>if this is a <see cref="PowerUpGameMapSquare"/></returns>
        bool IsPowerUpGameMapSquare();

        /// <summary>
        /// Returns if this is a <see cref="DamageGameMapSquare"/>
        /// </summary>
        /// <returns>if this is a <see cref="DamageGameMapSquare"/></returns>
        bool IsDamageGameMapSquare();
    }
}
