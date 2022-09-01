using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    class MedikitPowerup : IPowerup
    {
        public string PowerupType { get; } = "Medikit Power-Up";

        public bool UseOnSelf { get; } = true;

        public void UsePowerup(IPlayer target)
        {
            target.AddLifePoints(Player.Player.MAX_LIFE);
        }
    }
}
