using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    /// <summary>
    /// Implementation of <see cref="IPowerup"/>.
    /// </summary>
    class DoubleDicePowerup : IPowerup
    {
        public string PowerupType { get; } = "Double Dice Power-Up";

        public bool UseOnSelf { get; } = true;

        public void UsePowerup(IPlayer target)
        {
            target.DicesToRoll = 2;
        }
    }
}
