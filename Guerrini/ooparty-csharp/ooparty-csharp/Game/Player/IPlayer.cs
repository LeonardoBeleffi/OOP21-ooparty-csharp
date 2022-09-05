using ooparty_csharp.Game.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace ooparty_csharp.Game.Player
{
    public interface IPlayer
    {
        /// <summary>
        /// The amount of coins of the player.
        /// </summary>
        int Coins { get; }

        /// <summary>
        /// The amount of stars of the player.
        /// </summary>
        int Stars { get; }

        /// <summary>
        /// The amount of life points of the player.
        /// </summary>
        int LifePoints { get; }

        /// <summary>
        /// The amount of the last earned coins.
        /// </summary>
        int LastEarnedCoins { get; }

        /// <summary>
        /// The amount of the last damage taken.
        /// </summary>
        int LastDamageTaken { get; }

        /// <summary>
        /// True if the player went to a <see cref="StarGameMapSquare"/> and earned a star,
        /// false if the player went to a <see cref="StarGameMapSquare"/> and didn't earn a star.
        /// </summary>
        bool IsLastStarEarned { get; set; }

        /// <summary>
        /// If the player is dead (LifePoints is 0).
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Moves the player forward.
        /// </summary>
        /// <param name="n">number of steps</param>
        /// <param name="gameMap">the map of the game</param>
        void MoveForward(int n, IGameMap gameMap);

        /// <summary>
        /// Moves the player to a certain position.
        /// </summary>
        /// <param name="gameMap">the map of the game</param>
        /// <param name="newGameMapSquare">the new player's position square</param>
        void GoTo(IGameMap gameMap, IGameMapSquare newGameMapSquare);

        /// <summary>
        /// Returns the <see cref="IGameMapSquare"/> where this player is located.
        /// </summary>
        /// <param name="gameMap">the map of the game</param>
        /// <returns>the player's position (the <see cref="IGameMapSquare"/> where he is located)</returns>
        IGameMapSquare GetPosition(IGameMap gameMap);

        /// <summary>
        /// Increments the player's coins.
        /// </summary>
        /// <param name="n">coins to add</param>
        void EarnCoins(int n);

        /// <summary>
        /// Decrements the player's coins.
        /// </summary>
        /// <param name="n">coins to subtract</param>
        void LoseCoins(int n);

        /// <summary>
        /// Updates the player's coins.
        /// </summary>
        /// <param name="n">new amount of coins</param>
        void UpdateCoins(int n);

        /// <summary>
        /// Makes the player earn a star.
        /// </summary>
        void EarnStar();

        /// <summary>
        /// Makes the player lose a star.
        /// </summary>
        void LoseStar();

        /// <summary>
        /// Adds amount life points to the current life points.
        /// </summary>
        /// <param name="amount">the amount of life points to get</param>
        void AddLifePoints(int amount);

        /// <summary>
        /// Takes away life points from the player.
        /// </summary>
        /// <param name="damage">the amount of life to be taken away</param>
        void LoseLifePoints(int damage);

        /// <summary>
        /// Checks if the player is dead and if he is, makes him respawn.
        /// </summary>
        /// <param name="gameMap">the map of the game</param>
        void CheckIfDeadAndRespawn(IGameMap gameMap);
    }
}
