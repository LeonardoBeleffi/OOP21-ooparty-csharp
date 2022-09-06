using ooparty_csharp.Game.Player;

namespace ooparty_csharp.Game.Map
{
    /// <summary>
    /// A game map square where you can earn a star.
    /// </summary>
    public class StarGameMapSquare : GameMapSquare
    {
        /// <summary>
        /// Builder for <see cref="StarGameMapSquare"/>
        /// </summary>
        public StarGameMapSquare()
            : base()
        {
        }

        /// <summary>
        /// Adds a star to a player if that player has enough coins.
        /// </summary>
        /// <param name="p">the player that will receive the star</param>
        public new void MakeSpecialAction(IPlayer p)
        {
            if (this.CheckEnoughCoins(p))
            {
                p.EarnStar();
                p.LoseCoins(GameMap.CoinsToBuyStar);
                p.IsLastStarEarned = true;
            }
            else
            {
                p.IsLastStarEarned = false;
            }
        }

        private bool CheckEnoughCoins(IPlayer p)
        {
            return p.Coins >= GameMap.CoinsToBuyStar;
        }

        public new bool IsStarGameMapSquare()
        {
            return true;
        }

    }
}
