using ooparty_csharp.Game.Powerup;

namespace ooparty_csharp.Utils.Factories
{
    /// <summary>
    /// This interface models the power-up factory model.
    /// </summary>
    interface IPowerupFactory
    {
        /// <summary>
        /// This method returns a new random power-up.
        /// </summary>
        /// <returns>A new random power-up that implements <see cref="IPowerup"/>.</returns>
        IPowerup GetRandomPowerup();
    }
}
