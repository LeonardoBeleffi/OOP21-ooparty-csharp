using ooparty_csharp.Game.Player;
using System;

namespace ooparty_csharp.Game.Dice
{
    /// <summary>
    /// Specialization of <see cref="DiceModel"/>.
    /// </summary>
    class DiceModelNoRepeat: DiceModel
    {
        public new int RollDice(IPlayer player)
        {
            if(Results.Count == MAX_RESULT)
            {
                throw new Exception("No more available results");
            }
            int result;
            do
            {
                result = Rand.Next(1, MAX_RESULT);
            } while (Results.ConvertAll(p => p.Value).Contains(result));
            SetResult(player, result);
            return result;
        }
    }
}
