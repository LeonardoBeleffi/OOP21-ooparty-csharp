using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    /// <summary>
    /// Implementation of <see cref="IPowerup"/>.
    /// </summary>
    class GunPowerup : IPowerup
    {
        public string PowerupType { get; } = "Gun Power-Up";

        /// <summary>
        /// <c>GUN_DAMAGE</c> is the damage dealt by this power-up.
        /// </summary>
        private const int GUN_DAMAGE = 50;

        public bool UseOnSelf { get; } = false;

        public void UsePowerup(IPlayer target)
        {
            target.LoseLifePoints(GUN_DAMAGE);
        }
    }
}
