using ooparty_csharp.Game.Powerup;
using System;

namespace ooparty_csharp.Utils.Factories.Powerup
{
    /// <summary>
    /// Implementation of <see cref="IPowerupFactory"/>
    /// </summary>
    public class PowerupFactory : IPowerupFactory
    {
        private const int PowerupsNumber = 4;

        public IGenericPowerup GetRandomPowerup()
        {
            Random rand = new Random();
            return rand.Next(PowerupsNumber) switch
            {
                0 => new DoubleDicePowerup(),
                1 => new GunPowerup(),
                2 => new MedikitPowerup(),
                3 => new MagnetPowerup(),
                _ => new GunPowerup(),
            };
        }
    }
}
