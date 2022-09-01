using System.Collections.Generic;

namespace ooparty_csharp.Game.Player
{
    public interface IPlayer
    {
        string Nickname { get; }

        string Color { get; }

        int Coins { get; set; }

        int LastEarnedCoins { get; }

        int Stars { get; }

        bool IsLastStarEarned { get; set; }

        int LifePoints { get; }

        int LastDamageTaken { get; }

        bool IsDead { get; }

        int DicesToRoll { get; set; }

        List<IPowerup> Powerups { get; }

        void EarnCoins(int n);

        void LoseCoins(int n);

        void EarnStar();

        void LoseStar();

        void AddLifePoints(int n);

        void LoseLifePoints(int n);

        void AddPowerup(IPowerup powerup);

        void UsePowerup(string powerupType, IPlayer target);
    }
}