using System;
using System.Collections.Generic;
using Beleffi.Game.Dice.Controller;
using Beleffi.Game.Player;
using Beleffi.Minigames.Common.Controller;
using Beleffi.Minigames.Memo.Model;
using Beleffi.Minigames.Memo.View;
using Beleffi.Utils.Graphics.Controller;
using Beleffi.Utils.View;

namespace Beleffi.Minigames.Memo.Controller
{
    /// <summary>
    /// Implementation of <see cref="IMemoController"/>
    /// and extension of <see cref="Utils.Controller.AbstractGenericController"/>
    /// <typeparam name="TS">the scene of the stage.</typeparam>
    /// </summary>
    public class MemoController<TS> : AbstractMinigameController<TS>, IMemoController
    {
        private readonly IMemoModel _memoModel;
        private IMemoViewController _viewController;     
     
        /// <summary>
        /// Builder for <see cref="MemoController{TS}"/>
        /// </summary>
        /// <typeparam name="TS">the scene of the stage.</typeparam>
        /// <param name="s">the <see cref="IStageManager{TS}"/>.</param>
        /// <param name="model">the <see cref="IMemoModel"/>.</param>
        /// <param name="dice">the <see cref="IDiceController"/>.</param>
        /// <returns></returns>
        public MemoController(in IStageManager<TS> s, in IMemoModel model, in IDiceController dice)
            : base(s, dice)
        {
            _memoModel = model;
        }
        
        public IList<IPlayer> GetGameResults()
        {
            return _memoModel.GetGameResults();
        }
        
        public void StartGame() {
            GetStageManager().GetGui().GetViewLoader().CreateMemoView(this);
            var guideController = new MinigameGuideController<TS>(GetStageManager());
            GetStageManager().GetGui().GetViewLoader().CreateMemoGuideView(guideController);

            _viewController.Start(_memoModel.GetCards());
            _viewController.SetPlayerLabelText(_memoModel.GetCurrPlayer());
        }

        public void UpdateCurrentPlayerLabel() {
            _viewController.SetPlayerLabelText(_memoModel.GetCurrPlayer());
        }

        public void PickCard(in int cardValue) {
            _memoModel.SetValue(cardValue);
        }

        public IGenericViewController GetViewController() {
            return _viewController;
        }

        public void SetViewController(in IGenericViewController viewController) {
            if (viewController is IMemoViewController) {
                _viewController = (IMemoViewController) viewController;
            } else {
                throw new InvalidOperationException("The parameter must be an instance of MemoViewController");
            }
        }

        public bool NextTurn() {
            var temp = _memoModel.RunGame();
            if (IsOver()) {
                CloseGame();
            }
            return temp;
        }

        public bool IsOver() {
            return _memoModel.IsOver();
        }
    }
}
