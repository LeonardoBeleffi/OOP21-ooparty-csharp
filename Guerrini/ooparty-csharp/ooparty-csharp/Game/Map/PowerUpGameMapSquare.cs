using ooparty_csharp.Game.Player;
using ooparty_csharp.Game.Powerup;
using ooparty_csharp.Utils.Factories.Powerup;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// A game map square where you can get a <see cref="IGenericPowerup"/>.
    /// </summary>
    public class PowerUpGameMapSquare : GameMapSquare
    {
        private IGenericPowerup _powerup;

        /// <summary>
        /// Builder for <see cref="PowerUpGameMapSquare"/>
        /// </summary>
        public PowerUpGameMapSquare()
            : base()
        {
            this.GenerateRandomPowerUp();
        }

        private void GenerateRandomPowerUp()
        {
            IPowerupFactory powerupFactory = new PowerupFactory();
            this._powerup = powerupFactory.GetRandomPowerup();
        }

        /// <summary>
        /// Adds a <see cref="IGenericPowerup"/> to the player p and generates a new powerup on this square.
        /// </summary>
        /// <param name="p">the <see cref="IPlayer"/> that will receive the powerup</param>
        public new void MakeSpecialAction(IPlayer p)
        {
            p.AddPowerup(this._powerup);
            this.GenerateRandomPowerUp();
        }

        public new bool IsPowerUpGameMapSquare()
        {
            return true;
        }
    }
}
