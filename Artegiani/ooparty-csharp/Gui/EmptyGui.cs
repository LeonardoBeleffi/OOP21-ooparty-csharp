using System;
using Application.StageManager;

namespace ooparty_csharp.Gui
{
    /// <summary>
    /// Empty implementation of <see cref="IGui"/>.
    /// </summary>
    public class EmptyGui : IGui
    {
        /// <summary>
        /// Builds a <see cref="EmptyGui"/>.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="stageManager">The <see cref="IStageManager{S}"/> used.</param>
        public EmptyGui(string title)
        {
            throw new NotImplementedException();
        }

        public void CreateGui()
        {
            throw new NotImplementedException();
        }

        public bool MainStagePresence()
        {
            return false;
        }

        public void SetScene<S>(S scene)
        {
            throw new NotImplementedException();
        }
    }
}
