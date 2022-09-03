using System.Collections.Generic;

namespace Beleffi.Minigames.Memo.Model
{
    /// <summary>
    /// This interface models the minigame <b>memo</b>'s model. This interface is a
    /// specialization of <see cref="Beleffi.Minigames.Common.Model.IMinigameModel"/>.
    /// </summary>
    public interface IMemoModel : Beleffi.Minigames.Common.Model.IMinigameModel
    {
        
        /// <summary>
        /// This methods tells if the minigame has ended.
        /// </summary>
        /// <returns><b>true</b> if this game has ended, <b>false</b> otherwise.</returns>
        bool IsOver();

        /// <summary>
        /// This method tells the active cards.
        /// </summary>
        /// <returns>a list containing the active cards.</returns>
        List<int> GetCards();
        
        /// <summary>
        /// This method sets the value of the next card to be chosen.
        /// </summary>
        /// <param name="cardValue">the value of the card chosen.</param>
        void SetValue(int cardValue);
    }
}