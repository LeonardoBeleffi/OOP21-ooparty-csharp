using System;

namespace Application.StageManager
{
    public interface IGui
    {
        /// <summary>
        /// This method starts the gui.
        /// </summary>
        void CreateGui();

        /// <summary>
        /// This method checks if a main stage is present.
        /// </summary>
        /// <returns>True if a main stage is present else false.</returns>
        bool MainStagePresence();

        /// <summary>
        /// This method shows the actual scene.
        /// </summary>
        /// <typeparam name="S">The scenes of the stage.</typeparam>
        /// <param name="scene">The scene to show.</param>
        /// <exception cref="InvalidOperationException">If the main stage is not set.</exception>
        void SetScene<S>(S scene);
    }
}