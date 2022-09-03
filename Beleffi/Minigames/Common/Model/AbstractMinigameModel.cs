using System.Collections.Generic;
using Beleffi.Game.Dice.Model;
using Beleffi.Game.Player;

namespace Beleffi.Minigames.Common.Model
{
    public class AbstractMinigameModel
    {
        public AbstractMinigameModel(in IList<IPlayer> players, in IDiceModel dice)
        {
        }

        public int Score { get; set; }
        
        public bool HasCurrPlayer()
        {
            return false;
        }

        public void SetGameResults()
        {
        }

        public bool HasNextPlayer()
        {
            return false;
        }
        
        public void SetPlayerIterator(in IList<IPlayer> players)
        {
        }

        public IList<IPlayer> GetPlayers()
        {
            return new List<IPlayer>();
        }
        
        public void SetCurrPlayer()
        {
        }

        public void ScoreMapper(in IPlayer player, in int score)
        {
        }
    }
}