using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    public interface IPowerup
    {
        string PowerupType { get; }

        bool UseOnSelf { get; }

        void UsePowerup(IPlayer target);
    }
}