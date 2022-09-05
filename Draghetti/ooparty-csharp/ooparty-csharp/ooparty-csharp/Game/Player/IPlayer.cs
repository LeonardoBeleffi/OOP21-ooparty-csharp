using ooparty_csharp.Game.Powerup;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Player
{
    /// <summary>
    /// This interface models the player model.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// <c>Nickname</c> is the name of the player.
        /// </summary>
        string Nickname { get; }

        /// <summary>
        /// <c>Color</c> is the color of the player.
        /// </summary>
        string Color { get; }

        /// <summary>
        /// <c>Coins</c> is the number of coins owned by the player.
        /// </summary>
        int Coins { get; set; }

        /// <summary>
        /// <c>LastEarnedCoins</c> is the amount of coins last earned by the player.
        /// </summary>
        int LastEarnedCoins { get; }

        /// <summary>
        /// <c>Stars</c> is the number of stars the player has earned.
        /// </summary>
        int Stars { get; }

        /// <summary>
        /// <c>IsLastStarEarned</c> is true if the last time the player
        /// went on a star square, they earned it, false otherwhise.
        /// </summary>
        bool IsLastStarEarned { get; set; }

        /// <summary>
        /// <c>LifePoints</c> is the amount of lifepoints of the player.
        /// </summary>
        int LifePoints { get; }

        /// <summary>
        /// <c>LastDamageTaken</c> is the amount of damage taken by
        /// the player, the last time they took damage.
        /// </summary>
        int LastDamageTaken { get; }

        /// <summary>
        /// <c>IsDead</c> is true if the player is dead.
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// <c>DicesToRoll</c> is the number of dices the player has
        /// to roll during the next turn.
        /// </summary>
        int DicesToRoll { get; set; }

        /// <summary>
        /// <c>Powerups</c> is the <see cref="List"/ of the powerups owned by the player.>
        /// </summary>
        List<IPowerup> Powerups { get; }

        /// <summary>
        /// This method makes the player earn coins.
        /// </summary>
        /// <param name="n">The amount of coins to earn.</param>
        void EarnCoins(int n);

        /// <summary>
        /// This method makes the player lose coins.
        /// </summary>
        /// <param name="n">The amount of coins to lose.</param>
        void LoseCoins(int n);

        /// <summary>
        /// This mothod makes the player earn a star.
        /// </summary>
        void EarnStar();

        /// <summary>
        /// This method makes the player lose a star.
        /// </summary>
        void LoseStar();

        /// <summary>
        /// This method increases the player's lifepoints.
        /// </summary>
        /// <param name="n">The amount of lifepoints to add.</param>
        void AddLifePoints(int n);

        /// <summary>
        /// This method makes the player lose lifepoints.
        /// </summary>
        /// <param name="n">The amount of lifepoints to lose.</param>
        void LoseLifePoints(int n);

        /// <summary>
        /// This method gives a power-up to the player.
        /// </summary>
        /// <param name="powerup">The power-up to give to the player.</param>
        void AddPowerup(IPowerup powerup);

        /// <summary>
        /// This method makes the player use a power-up
        /// </summary>
        /// <param name="powerupType">The type of the power-up to use.</param>
        /// <param name="target">The player the power-up is used towards.</param>
        void UsePowerup(string powerupType, IPlayer target);
    }
}