using Beleffi.Game.Dice.Controller;
using Beleffi.Utils.Graphics.Controller;

namespace Beleffi.Minigames.Common.Controller
{
    public class AbstractMinigameController<TS>
    {
        public AbstractMinigameController(in IStageManager<TS> s, in IDiceController dice)
        {
        }

        public IStageManager<TS> GetStageManager()
        {
            return null;
        }


        public void CloseGame()
        {
        }
    }
}