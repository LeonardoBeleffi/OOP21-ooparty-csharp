namespace Beleffi.Minigames.Memo.Controller
{
    /// <summary>
    /// This interface models the minigame <b>memo</b>'s controller.
    /// This interface is a specialization of <see cref="Beleffi.Minigames.Common.Controller.IMinigameController"/>
    /// </summary>
    public interface IMemoController : Beleffi.Minigames.Common.Controller.IMinigameController
    {
        /// <summary>
        /// This method updates the view with the name of the current player.
        /// </summary>
        void UpdateCurrentPlayerLabel();

        /// <summary>
        /// This method picks a card.
        /// </summary>
        /// <param name="cardValue">the value of the card.</param>
        void PickCard(in int cardValue);

        /// <summary>
        /// This methods tells whether the game has ended.
        /// </summary>
        /// <returns><b>true</b> if the game has ended, <b>false</b> otherwise.</returns>
        bool IsOver();
    }
}