using System.Collections.Generic;
using Application.Minigames.Common.Controller;

namespace Application.StageManager
{
    /// <summary>
	/// This interface models a stage manager.
	/// </summary>
	/// <typeparam name="S">The scenes of the stage.</typeparam>
    public interface IStageManager<S>
    {
        /// <summary>
	    /// <c>LastGameController</c> represents the controller of the last minigame played.
	    /// </summary>
        IMinigameController LastGameController { get; set; }

        /// <summary>
        /// Gets the gui used.
        /// </summary>
        IGui Gui { get; }

        /// <summary>
        /// This method adds an existing scene.
        /// </summary>
        /// <param name="scene">The scene to add.</param>
        void AddScene(S scene);

        /// <summary>
        /// This method pops a scene from the scenes list.
        /// </summary>
        /// <returns>The popped scene.</returns>
        S PopScene();

        /// <summary>
        /// This method starts the gui.
        /// </summary>
        void Run();

        /// <summary>
        /// This method returns the list of all scenes.
        /// </summary>
        /// <returns>All the scenes.</returns>
        Stack<S> Scenes { get; }
    }
}
