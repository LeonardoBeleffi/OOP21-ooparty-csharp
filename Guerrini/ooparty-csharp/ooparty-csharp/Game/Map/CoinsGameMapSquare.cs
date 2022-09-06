using ooparty_csharp.Game.Player;
using System;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// A game map square where you earn coins.
    /// </summary>
    public class CoinsGameMapSquare : GameMapSquare
    {
        private int _coinsNumber;

        /// <summary>
        /// Builder for <see cref="CoinsGameMapSquare"/>
        /// </summary>
        public CoinsGameMapSquare()
            : base()
        {
            this.GenerateNewCoins();
        }

        /// <summary>
        /// Builder for <see cref="CoinsGameMapSquare"/>
        /// </summary>
        /// <param name="coinsNumber">the amount of coins that will be contained in this square</param>
        public CoinsGameMapSquare(int coinsNumber)
            : base()
        {
            this._coinsNumber = coinsNumber;
        }

        /// <summary>
        /// Adds the coins to the player p.
        /// </summary>
        /// <param name="p">the player that is going to receive the coins</param>
        public new void MakeSpecialAction(IPlayer p)
        {
            p.EarnCoins(this._coinsNumber);
            this.GenerateNewCoins();
        }

        public new bool IsCoinsGameMapSquare()
        {
            return true;
        }

        private void GenerateNewCoins()
        {
            this._coinsNumber = new Random().Next(GameMapSquare.MaxCoins) + 1;
        }
    }
}
