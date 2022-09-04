using System.Collections.Generic;
using Beleffi.Game.Player;
using Beleffi.Utils.View;

namespace Beleffi.Minigames.Memo.View
{
    public interface IMemoViewController : IGenericViewController
    {
        void Start(in IList<int> cards);

        void SetPlayerLabelText(in IPlayer player);
    }
}