using Beleffi.Minigames.Common.Controller;
using Beleffi.Minigames.Memo.Controller;

namespace Beleffi.Utils.View
{
    public interface IViewLoader
    {
        void CreateMemoView(in IMemoController memoController);
        
        void CreateMemoGuideView(in IMinigameGuideController guideController);
    }
}