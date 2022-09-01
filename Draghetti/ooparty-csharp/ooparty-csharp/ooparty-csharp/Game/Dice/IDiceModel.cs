using ooparty_csharp.Game.Player;
using System.Collections.Generic;

namespace ooparty_csharp.Game.Dice
{
    public interface IDiceModel
    {
        int? LastResult { get; }

        List<KeyValuePair<IPlayer, int>> Results { get; }

        int RollDice(IPlayer player);

        void Reset();

        int GetTotal();
    }
}
