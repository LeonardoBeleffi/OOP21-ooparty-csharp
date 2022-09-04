using System.Collections.Generic;
using Beleffi.Game.Dice.Model;
using Beleffi.Game.Player;

namespace Beleffi.Minigames.Common.Model
{
    public class AbstractMinigameModel : IMinigameModel
    {
        public AbstractMinigameModel(in IList<IPlayer> players, in IDiceModel dice)
        {
        }

        public int Score { get; set; }
        
        public bool HasCurrPlayer()
        {
            return false;
        }

        public IList<IPlayer> GetGameResults()
        {
            return null;
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

        public IPlayer GetCurrPlayer()
        {
            return null;
        }
        
        public void SetCurrPlayer()
        {
        }

        public void ScoreMapper(in IPlayer player, in int score)
        {
        }

        public bool RunGame()
        {
            return false;
        }
    }
}
