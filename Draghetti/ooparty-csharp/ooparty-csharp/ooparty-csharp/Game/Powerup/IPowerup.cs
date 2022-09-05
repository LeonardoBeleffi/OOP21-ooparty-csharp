using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Powerup
{
    /// <summary>
    /// This interface models a generic power-up.
    /// </summary>
    public interface IPowerup
    {
        /// <summary>
        /// <c>PowerupType</c> is the type of the power-up.
        /// </summary>
        string PowerupType { get; }

        /// <summary>
        /// <c>UseOnSelf</c> is true if a player must use the power-up
        /// towards themself, false if against the other players. 
        /// </summary>
        bool UseOnSelf { get; }

        /// <summary>
        /// This method makes the power-up apply its effect
        /// on a target player.
        /// </summary>
        /// <param name="target">The player to apply the effect to.</param>
        void UsePowerup(IPlayer target);
    }
}