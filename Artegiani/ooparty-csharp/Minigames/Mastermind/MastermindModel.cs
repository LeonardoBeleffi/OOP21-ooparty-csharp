using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ooparty_csharp.Game.Dice;
using ooparty_csharp.Game.Player;
using ooparty_csharp.Minigames.Common.Model;

namespace ooparty_csharp.Minigames.Mastermind
{
    /// <summary>
    /// Implementation of <see cref="IMastermindModel"/> and specialization of
    /// <see cref="MinigameModelAbstr"/>.
    /// </summary>
    public class MastermindModel : MinigameModelAbstr, IMastermindModel
    {
        private const string EmptyString = "";

        /// <summary>
        /// Builds a <see cref="MastermindModel"/>.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="dice"></param>
        public MastermindModel(List<IPlayer> players, DiceModelNoRepeat dice) : base(players, dice)
        {
        }

        public bool Win { get; private set; }

        public bool Lose { get; private set; }

        public string Solution { get; private set; }

        public int MaxAttempts { get; set; }

        public int NAttempts { get; private set; }

        public string DoAttempt(string attempt)
        {
            if (CheckAttempt(attempt))
            {
                NAttempts++;
                int nDigitPresent = CheckDigitsPresence(attempt);
                int nDigitExact = CheckDigitsPosition(attempt);
                WinCheck(nDigitExact);
                return CreateAttemptLabel(attempt, nDigitPresent, nDigitExact);
            }
            else
            {
                return EmptyString;
            }
        }

        public override bool RunGame()
        {
            if (PlayerEnumerator.MoveNext())
            {
                NAttempts = 0;
                Win = false;
                Lose = false;
                Solution = GenerateSolution();
                return true;
            }
            SetGameResults();
            return false;
        }

        private string GenerateSolution()
        {
            string number = "";
            string[] digitArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var digits = new List<string>(digitArray);
            while (number.Length < 4)
            {
                int index = new Random().Next(digits.Count);
                number += digits[index];
                digits.RemoveAt(index);
            }
            return number;
        }

        private bool CheckAttempt(string attempt)
        {
            if (attempt.Length != 4)
            {
                return false;
            }
            foreach (char c in attempt.ToCharArray())
            {
                if (char.IsLetter(c))
                {
                    return false;
                }
            }
            return attempt.Distinct().ToList().Count == 4;
        }

        private void WinCheck(int nDigitExact)
        {
            if (nDigitExact == 4)
            {
                Score = MaxAttempts - NAttempts + 1;
                Win = true;
            }
            else
            {
                LoseCheck();
            }
        }

        private void LoseCheck()
        {
            if (NAttempts == MaxAttempts)
            {
                Score = MaxAttempts - NAttempts;
                Lose = true;
            }
        }

        private int CheckDigitsPresence(string attempt)
        {
            int nDigit = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Solution.Contains(attempt[i]))
                {
                    nDigit++;
                }
            }
            return nDigit;
        }

        private int CheckDigitsPosition(string attempt)
        {
            int nDigit = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Solution[i] == attempt[i])
                {
                    nDigit++;
                }
            }
            return nDigit;
        }

        private string CreateAttemptLabel(string attempt, int nDigitPresent, int nDigitExact)
        {
            return attempt + "\n" + nDigitPresent + " common digits of \nwhich " + nDigitExact + " in correct position.";
        }
    }
}
