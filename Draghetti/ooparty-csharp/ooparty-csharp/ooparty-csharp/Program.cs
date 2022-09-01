using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooparty_csharp
{
    public interface IDiceModel
    {
        int RollDice(Player player);

        void Reset();

        int? GetLastResult();

        List<Pair<Player, int>> GetResults();

        int GetTotal();
    }
}
