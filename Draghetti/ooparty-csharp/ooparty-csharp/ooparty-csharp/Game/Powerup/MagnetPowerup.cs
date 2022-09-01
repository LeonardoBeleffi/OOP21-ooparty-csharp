using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    class MagnetPowerup: IPowerup
    {
        public string PowerupType { get; } = "Magnet Power-Up";

        public bool UseOnSelf { get; } = false;

        public void UsePowerup(IPlayer target)
        {
            target.LoseCoins(target.Coins / 3);
        }
    }
}
