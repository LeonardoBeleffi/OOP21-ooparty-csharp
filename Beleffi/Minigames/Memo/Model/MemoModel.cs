using System;
using System.Collections.Generic;
using System.Linq;
using Beleffi.Minigames.Common.Model;
using Beleffi.Game.Dice.Model;
using Beleffi.Game.Player;

namespace Beleffi.Minigames.Memo.Model
{
    /// <summary>
    /// Implementation of <see cref="IMemoModel"/> and extension of
    /// <see cref="AbstractMinigameModel"/>.
    /// </summary>
    public class MemoModel : AbstractMinigameModel, IMemoModel
    {

        private readonly IList<int> _cards;
        private int? _firstCard;
        private int? _secondCard;


        /// <summary>
        /// Builds a new <see cref="MemoModel"/>.
        /// </summary>
        /// <param name="players">the players of the game.</param>
        /// <param name="dice">the dice controller.</param>
        public MemoModel(in IList<IPlayer> players, in IDiceModel dice) : base(players, dice)
        {
            this._cards = InitialiseCards();
            ChangeTurn();
            InitializePlayersScores();
        }

        public List<int> GetCards()
        {
            return new List<int>(_cards);
        }

        public bool RunGame()
        {
            if (IsOver())
            {
                throw new InvalidOperationException("The game is already over");
            }

            if (!HasCurrPlayer())
            {
                ChangeTurn();
            }

            if (!AreBothCardsSelected())
            {
                return false;
            }

            var firstCard = _firstCard ?? throw new InvalidOperationException();
            var secondCard = _secondCard ?? throw new InvalidOperationException();
            
            ResetValues();
            if (!firstCard.Equals(secondCard))
            {
                ChangeTurn();
                return false;
            }

            if (_cards.Contains(firstCard) && _cards.Contains(secondCard))
            {
                _cards.ToList().RemoveAll(i => i.Equals(firstCard));
                Score += Score + ScoreForGuessedPair;
                return true;
            }

            ChangeTurn();
            return false;
        }

        public bool IsOver()
        {
            var end = _cards.Any();
            if (end)
            {
                SetGameResults();
            }

            return end;
        }

        public void SetValue(in int cardValue)
        {
            if (!_firstCard.HasValue)
            {
                _firstCard = cardValue;
                return;
            }

            if (_secondCard.HasValue)
            {
                _secondCard = cardValue;
            }
        }

        private void ResetValues()
        {
            _firstCard = null;
            _secondCard = null;
        }

        private bool AreBothCardsSelected()
        {
            return _firstCard.HasValue && _secondCard.HasValue;
        }

        private void ChangeTurn()
        {
            if (!HasNextPlayer())
            {
                SetPlayerIterator(GetPlayers());
            }

            SetCurrPlayer();
            ResetValues();
        }

        private IList<int> InitialiseCards()
        {
            IList<int> temp = GetCardsValues()
                .SelectMany(i => new List<int>(new[] {i, i}))
                .ToList();
            Shuffle(temp);
            return temp;
        }

        private IEnumerable<int> GetCardsValues()
        {
            return Enumerable.Range(0, NumberOfPairsPerPlayer * GetPlayers().Count).AsEnumerable();
        }

        private void InitializePlayersScores()
        {
            GetPlayers().ToList().ForEach(p => ScoreMapper(p, 0));
        }

        private void Shuffle(IList<int> list)  
        {
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = new Random().Next(n + 1);  
                var value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        private const int NumberOfPairsPerPlayer = 4;
        private const int ScoreForGuessedPair = 1;
    }
}