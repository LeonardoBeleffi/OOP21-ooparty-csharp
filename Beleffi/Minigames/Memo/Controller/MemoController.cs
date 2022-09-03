using System.Collections.Generic;
using Beleffi.Game.Dice.Controller;
using Beleffi.Minigames.Common.Controller;
using Beleffi.Minigames.Memo.Controller;
using Beleffi.Minigames.Memo.Model;
using Beleffi.Minigames.Memo.View;
using Beleffi.Utils.Graphics.Controller;

namespace Beleffi.Minigames.Memo.Controller
{
    /// <summary>
    /// Implementation of <see cref="IMemoController"/>
    /// and extension of <see cref="Utils.Controller.AbstractGenericController"/>
    /// <typeparam name="S">the scene of the stage.</typeparam>
    /// </summary>
    public class MemoController<S> : AbstractMinigameController<S>, IMemoController
    {
        private readonly IMemoModel _memoModel;
        private IMemoViewController _viewController;     
     
        /// <summary>
        /// Builder for <see cref="MemoController{S}"/>
        /// </summary>
        /// <typeparam name="S">the scene of the stage.</typeparam>
        /// <param name="s">the <see cref="IStageManager{S}"/>.</param>
        /// <param name="model">the <see cref="IMemoModel"/>.</param>
        /// <param name="dice">the <see cref="IDiceController"/>.</param>
        /// <returns></returns>
        public MemoController(in IStageManager<S> s, in IMemoModel model, in IDiceController dice)
            : base(s, dice)
        {
            this._memoModel = model;
        }
        
        public List<Player> GetGameResults()
        {
            return this._memoModel.GetGameResults();
        }
        
        public void StartGame() {
            this.getStageManager().getGui().getViewLoader().createMemoView(this);
            readonly IGenericController guideController = new MinigameGuideControllerImpl(this.getStageManager());
            this.getStageManager().getGui().getViewLoader().createMemoGuideView(guideController);

            this._viewController.start(this._memoModel.GetCards());
            this._viewController.setPlayerLabelText(this._memoModel.getCurrPlayer());
        }

        public void UpdateCurrentPlayerLabel() {
            this._viewController.setPlayerLabelText(this._memoModel.getCurrPlayer());
        }

        public void PickCard(in int cardValue) {
            this._memoModel.setValue(cardValue);
        }

        public GenericViewController GetViewController() {
            return this._viewController;
        }

        public void SetViewController(in IGenericViewController viewController) {
            if (viewController is IMemoViewController) {
                this._viewController = (IMemoViewController) viewController;
            } else {
                throw new IllegalArgumentException("The parameter must be an instance of MemoViewController");
            }
        }

        public bool NextTurn() {
            var temp = this._memoModel.runGame();
            if (this.IsOver()) {
                this.closeGame();
            }
            return temp;
        }

        public bool IsOver() {
            return this._memoModel.isOver();
        }
    }
}