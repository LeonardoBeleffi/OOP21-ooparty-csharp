using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    class GunPowerup : IPowerup
    {
        public string PowerupType { get; } = "Gun Power-Up";

        private const int GUN_DAMAGE = 50;

        public bool UseOnSelf { get; } = false;

        public void UsePowerup(IPlayer target)
        {
            target.LoseLifePoints(GUN_DAMAGE);
        }
    }
}
