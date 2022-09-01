using ooparty_csharp.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ooparty_csharp.Game.Dice
{
    class DiceModel : IDiceModel
    {
        protected const int MAX_RESULT = 6;

        protected Random Rand;

        public int? LastResult { get; private set; }

        public List<KeyValuePair<IPlayer, int>> Results { get; private set; }

        public DiceModel()
        {
            Rand = new Random();
            LastResult = null;
            Results = new List<KeyValuePair<IPlayer, int>>();
        }

        public int GetTotal()
        {
            return Results.Sum(p => p.Value);
        }

        public void Reset()
        {
            LastResult = null;
            Results = new List<KeyValuePair<IPlayer, int>>();
        }

        public int RollDice(IPlayer player)
        {
            int result = Rand.Next(1, MAX_RESULT);
            SetResult(player, result);
            return result;
        }

        protected void SetResult(IPlayer player, int result)
        {
            LastResult = result;
            Results.Add(new KeyValuePair<IPlayer, int>(player, result));
        }
    }
}
