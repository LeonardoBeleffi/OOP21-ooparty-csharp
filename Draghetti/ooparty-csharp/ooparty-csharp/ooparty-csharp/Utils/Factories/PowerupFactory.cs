using ooparty_csharp.Game.Powerup;
using System;

namespace ooparty_csharp.Utils.Factories
{
    /// <summary>
    /// Implementation of <see cref="IPowerupFactory"/>
    /// </summary>
    class PowerupFactory : IPowerupFactory
    {
        private const int POWERUPS_NUMBER = 4;

        public IPowerup GetRandomPowerup()
        {
            Random rand = new Random();
            switch (rand.Next(POWERUPS_NUMBER))
            {
                case 0:
                    return new DoubleDicePowerup();
                case 1:
                    return new GunPowerup();
                case 2:
                    return new MedikitPowerup();
                case 3:
                    return new MagnetPowerup();
                default:
                    return new GunPowerup();
            }
        }
    }
}
