using ooparty_csharp.Game.Powerup;
using System;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Player
{
    /// <summary>
    /// Implementation of <see cref="IPlayer"/>
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// <c>MAX_LIFE</c> is the maximum amount of lifepoints for a player.
        /// </summary>
        public const int MAX_LIFE = 100;

        public string Nickname { get; private set; }

        public string Color { get; private set; }

        public int Coins { get; set; }

        public int LastEarnedCoins { get; private set; }

        public int Stars { get; private set; }

        public bool IsLastStarEarned { get; set; }

        public int LifePoints { get; private set; }

        public int LastDamageTaken { get; private set; }

        public bool IsDead { get; private set; }

        public int DicesToRoll { get; set; }

        public List<IPowerup> Powerups { get; }

        /// <summary>
        /// Builds a <see cref="Player"/>.
        /// </summary>
        /// <param name="nickname">The selected nickname.</param>
        /// <param name="color">The selected color.</param>
        public Player(string nickname, string color)
        {
            Nickname = nickname;
            Color = color;
            Coins = 0;
            LastEarnedCoins = 0;
            Stars = 0;
            IsLastStarEarned = false;
            LifePoints = MAX_LIFE;
            LastDamageTaken = 0;
            IsDead = false;
            DicesToRoll = 1;
            Powerups = new List<IPowerup>();
        }

        public void AddLifePoints(int n)
        {
            if (n <= 0)
            {
                throw new Exception("n can't be 0 or negative");
            }
            LifePoints += n;
            if (LifePoints >= MAX_LIFE)
            {
                LifePoints = MAX_LIFE;
            }
        }

        public void AddPowerup(IPowerup powerup)
        {
            Powerups.Add(powerup);
        }

        public void EarnCoins(int n)
        {
            if (n <= 0)
            {
                throw new Exception("n can't be 0 or negative");
            }
            Coins += n;
            LastEarnedCoins = n;
        }

        public void EarnStar()
        {
            Stars++;
        }

        public void LoseCoins(int n)
        {
            if (n <= 0)
            {
                throw new Exception("n can't be 0 or negative");
            }
            Coins -= n;
            if (Coins < 0)
            {
                Coins = 0;
            }
        }

        public void LoseLifePoints(int n)
        {
            if (n <= 0)
            {
                throw new Exception("n can't be 0 or negative");
            }
            LifePoints -= n;
            LastDamageTaken = n;
            if (LifePoints <= 0)
            {
                LifePoints = 0;
                IsDead = true;
                Coins /= 2;
            }
        }

        public void LoseStar()
        {
            if (Stars > 0)
            {
                Stars--;
            }
        }

        public void UsePowerup(string powerupType, IPlayer target)
        {
            IPowerup powerup = Powerups.Find(p => p.PowerupType.Equals(powerupType));
            if (powerup != null)
            {
                powerup.UsePowerup(target);
                Powerups.Remove(powerup);
            }
        }
    }
}
