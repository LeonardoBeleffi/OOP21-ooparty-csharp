using ooparty_csharp.Game.Powerup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ooparty_csharp.Utils.Factories.Powerup
{
    /// <summary>
    /// A factory for <see cref="IGenericPowerup"/>.
    /// </summary>
    public interface IPowerupFactory
    {
        /// <summary>
        /// Returns a random <see cref="IGenericPowerup"/>.
        /// </summary>
        /// <returns>a random <see cref="IGenericPowerup"/></returns>
        IGenericPowerup GetRandomPowerup();
    }
}
