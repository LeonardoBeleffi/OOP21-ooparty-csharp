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

        private readonly IList<int> cards;
        private int? firstCard;
        private int? secondCard;


        /// <summary>
        /// Builds a new <see cref="MemoModel"/>.
        /// </summary>
        /// <param name="players">the players of the game.</param>
        /// <param name="dice">the dice controller.</param>
        public MemoModel(in IList<IPlayer> players, in IDiceModel dice) : base(players, dice)
        {
            this.cards = this.InitialiseCards();
            this.ChangeTurn();
            this.InitializePlayersScores();
        }

        public List<int> GetCards()
        {
            return new List<int>(this.cards);
        }

        public bool RunGame()
        {
            if (this.IsOver())
            {
                throw new InvalidOperationException("The game is already over");
            }

            if (!this.HasCurrPlayer())
            {
                this.ChangeTurn();
            }

            if (!this.AreBothCardsSelected())
            {
                return false;
            }

            var firstCard = this.firstCard ?? new Nullable<int>();
            var secondCard = this.secondCard ?? new Nullable<int>();
            
            this.ResetValues();
            if (!firstCard.equals(secondCard))
            {
                this.ChangeTurn();
                return false;
            }

            if (this.cards.contains(firstCard) && this.cards.contains(secondCard))
            {
                this.cards.removeIf(i->i.equals(firstCard));
                this.setScore(this.getScore() + SCORE_FOR_GUESSED_PAIR);
                return true;
            }

            this.ChangeTurn();
            return false;
        }

        public bool IsOver()
        {
            final var end = this.cards.isEmpty();
            if (end)
            {
                this.setGameResults();
            }

            return end;
        }

        public void setValue(in int cardValue)
        {
            if (this.firstCard.isEmpty())
            {
                this.firstCard = Optional.of(cardValue);
                return;
            }

            if (this.secondCard.isEmpty())
            {
                this.secondCard = Optional.of(cardValue);
            }
        }

        private void ResetValues()
        {
            this.firstCard = Optional.empty();
            this.secondCard = Optional.empty();
        }

        private boolean areBothCardsSelected()
        {
            return this.firstCard.isPresent() && this.secondCard.isPresent();
        }

        private void ChangeTurn()
        {
            if (!this.HasNextPlayer())
            {
                this.setPlayerIterator(this.getPlayers());
            }

            this.setCurrPlayer();
            this.ResetValues();
        }

        private IList<int> InitialiseCards()
        {
            
            IList<int> temp = this.GetCardsValues().SelectMany(i => new List<int>(){1, 1}.GetEnumerator()).ToList();
            this.Shuffle(temp);
            return temp;
        }

        private IEnumerable<int> GetCardsValues()
        {
            return Enumerable.Range(0, NUMBER_OF_PAIRS_PER_PLAYER * this.getPlayers().size()).AsEnumerable();
        }

        private void InitializePlayersScores()
        {
            this.GetPlayers().forEach(p => this.ScoreMapper(p, 0));
        }

        private void Shuffle(IList<int> list)  
        {  
            Random rng = new Random();
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = rng.Next(n + 1);  
                var value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        private static readonly int NUMBER_OF_PAIRS_PER_PLAYER = 4;
        private static readonly int SCORE_FOR_GUESSED_PAIR = 1;
    }
}