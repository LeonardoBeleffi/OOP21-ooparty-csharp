using Beleffi.Game.Dice.Controller;
using Beleffi.Utils.Graphics.Controller;

namespace Beleffi.Minigames.Common.Controller
{
    public class AbstractMinigameController<S>
    {
        public AbstractMinigameController(in IStageManager<S> s, in IDiceController dice)
        {
        }
    }
}