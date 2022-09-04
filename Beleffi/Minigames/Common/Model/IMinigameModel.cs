using System.Collections.Generic;
using Beleffi.Game.Player;

namespace Beleffi.Minigames.Common.Model
{
    public interface IMinigameModel
    {
        int Score { get; set; }

        bool HasCurrPlayer();

        IList<IPlayer> GetGameResults();
 
        void SetGameResults();

        bool HasNextPlayer();

        void SetPlayerIterator(in IList<IPlayer> players);

        IList<IPlayer> GetPlayers();

        IPlayer GetCurrPlayer();

        void SetCurrPlayer();

        void ScoreMapper(in IPlayer player, in int score);

        bool RunGame();
    }
}
