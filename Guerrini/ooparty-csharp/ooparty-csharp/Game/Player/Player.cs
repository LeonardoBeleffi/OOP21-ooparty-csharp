using ooparty_csharp.Game.Map;
using ooparty_csharp.Game.Powerup;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Player
{
    /// <summary>
    /// The implementation of <see cref="IPlayer"/>.
    /// </summary>
    public class Player : IPlayer
    {
        public int Coins { get; private set; }

        public int Stars { get; private set; }

        public int LifePoints { get; private set; }

        public int LastEarnedCoins { get; private set; }

        public int LastDamageTaken { get; private set; }

        public bool IsLastStarEarned { get; set; }

        public bool IsDead { get; private set; }

        public IList<IGenericPowerup> Powerups { get; }

        /// <summary>
        /// The maximum amount of life points.
        /// </summary>
        public const int MaxLife = 100;

        /// <summary>
        /// Builds a new <see cref="Player"/>
        /// </summary>
        public Player()
        {
            this.Coins = 0;
            this.LastEarnedCoins = 0;
            this.Stars = 0;
            this.IsLastStarEarned = false;
            this.LifePoints = Player.MaxLife;
            this.LastDamageTaken = 0;
            this.Powerups = new List<IGenericPowerup>();
            this.IsDead = false;
        }

        public void AddLifePoints(int amount)
        {
            if (amount <= 0)
            {
                throw new System.ArgumentException("Amount can't be 0 or negative");
            }
            this.LifePoints += amount;
            if (this.LifePoints > Player.MaxLife)
            {
                this.LifePoints = Player.MaxLife;
            }
        }

        public void CheckIfDeadAndRespawn(IGameMap gameMap)
        {
            if (this.IsDead)
            {
                this.Death(gameMap);
            }
        }

        private void Death(IGameMap gameMap)
        {
            this.Respawn(gameMap);
            this.LifePoints = Player.MaxLife;
            this.IsDead = false;
        }
        
        private void Respawn(IGameMap gameMap)
        {
            int firstFreeSquareIndex = this.GetStarSquareIndex(gameMap) + 1;
            if (firstFreeSquareIndex >= gameMap.Squares.Count)
            {
                firstFreeSquareIndex = 0;
            }
            while(gameMap.Squares[firstFreeSquareIndex].IsCoinsGameMapSquare()
                || gameMap.Squares[firstFreeSquareIndex].IsPowerUpGameMapSquare()
                || gameMap.Squares[firstFreeSquareIndex].IsDamageGameMapSquare()
                || gameMap.Squares[firstFreeSquareIndex].IsStarGameMapSquare())
            {
                firstFreeSquareIndex++;
                if (firstFreeSquareIndex >= gameMap.Squares.Count)
                {
                    firstFreeSquareIndex = 0;
                }
            }
            this.GoTo(gameMap, gameMap.Squares[firstFreeSquareIndex]);
        }

        private int GetStarSquareIndex(IGameMap gameMap)
        {
            int starSquareIndex = 0;
            foreach (IGameMapSquare s in gameMap.Squares)
            {
                if (s.IsStarGameMapSquare())
                {
                    starSquareIndex = gameMap.Squares.IndexOf(s);
                }
            }
            return starSquareIndex;
        }

        public void EarnCoins(int n)
        {
            if (n <= 0)
            {
                throw new System.ArgumentException("n can't be 0 or negative");
            }
            this.Coins += n;
            this.LastEarnedCoins = n;
        }

        public void EarnStar()
        {
            this.Stars++;
        }

        public IGameMapSquare GetPosition(IGameMap gameMap)
        {
            return gameMap.GetPlayerPosition(this);
        }

        public void GoTo(IGameMap gameMap, IGameMapSquare newGameMapSquare)
        {
            IGameMapSquare currentPosition = this.GetPosition(gameMap);
            newGameMapSquare.AddPlayer(this);
            currentPosition.RemovePlayer(this);
        }

        public void LoseCoins(int n)
        {
            if (n <= 0)
            {
                throw new System.ArgumentException("n can't be 0 or negative");
            }
            this.Coins -= n;
            if (this.Coins < 0)
            {
                this.Coins = 0;
            }
        }

        public void LoseLifePoints(int damage)
        {
            if (damage <= 0)
            {
                throw new System.ArgumentException("Damage can't be 0 or negative");
            }
            this.LifePoints -= damage;
            this.LastDamageTaken = damage;
            if (this.LifePoints <= 0)
            {
                this.IsDead = true;
                this.LifePoints = 0;
                this.UpdateCoins(this.Coins / 2);
            }
        }

        public void LoseStar()
        {
            if (this.Stars > 0)
            {
                this.Stars--;
            }
        }

        public void MoveForward(int n, IGameMap gameMap)
        {
            if (n <= 0)
            {
                throw new System.ArgumentException("n can't be 0 or negative");
            }
            int currentSquareIndex = gameMap.Squares.IndexOf(this.GetPosition(gameMap));
            int newSquareIndex = currentSquareIndex + n;
            if (newSquareIndex >= gameMap.Squares.Count)
            {
                newSquareIndex -= gameMap.Squares.Count;
            }
            this.GoTo(gameMap, gameMap.Squares[newSquareIndex]);
        }

        public void UpdateCoins(int n)
        {
            if (n >= 0)
            {
                this.Coins = n;
            } else
            {
                throw new System.ArgumentException("Coins can't be negative");
            }
        }

        public void AddPowerup(IGenericPowerup powerup)
        {
            this.Powerups.Add(powerup);
        }
    }
}
