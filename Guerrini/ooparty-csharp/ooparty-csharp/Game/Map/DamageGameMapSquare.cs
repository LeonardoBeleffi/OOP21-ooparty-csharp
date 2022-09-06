using ooparty_csharp.Game.Player;
using System;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// A game map square where you get damage.
    /// </summary>
    public class DamageGameMapSquare : GameMapSquare
    {
        private int _damage;

        /// <summary>
        /// Builder for <see cref="DamageGameMapSquare"/>
        /// </summary>
        public DamageGameMapSquare()
            : base()
        {
            this.GenerateNewDamage();
        }

        /// <summary>
        /// Builder for <see cref="DamageGameMapSquare"/>
        /// </summary>
        /// <param name="damage">the damage that will be contained in this square</param>
        public DamageGameMapSquare(int damage)
            : base()
        {
            this._damage = damage;
        }

        /// <summary>
        /// Makes the player p lose life points.
        /// </summary>
        /// <param name="p">the player that is going to lose life points</param>
        public new void MakeSpecialAction(IPlayer p)
        {
            p.LoseLifePoints(this._damage);
            this.GenerateNewDamage();
        }

        public new bool IsDamageGameMapSquare()
        {
            return true;
        }

        private void GenerateNewDamage()
        {
            this._damage = new Random().Next(GameMapSquare.MaxDamage) + 1;
        }
    }
}
