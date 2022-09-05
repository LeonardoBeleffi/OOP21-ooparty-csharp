using ooparty_csharp.Game.Player;
using System;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// A game map square where you earn coins.
    /// </summary>
    class CoinsGameMapSquare : GameMapSquare
    {
        private int _coinsNumber;
        public CoinsGameMapSquare()
            : base()
        {
            this.GenerateNewCoins();
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

        private void GenerateNewCoins()
        {
            this._coinsNumber = new Random().Next(GameMapSquare.MaxCoins) + 1;
        }
    }
}
