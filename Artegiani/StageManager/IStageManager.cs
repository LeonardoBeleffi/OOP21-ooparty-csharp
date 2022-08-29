using System;
namespace Application
{
    /// <summary>
	/// This interface models a stage manager.
	/// </summary>
	/// <typeparam name="S">The scenes of the stage.</typeparam>
    public interface IStageManager<S>
    {
        /// <value><c>LastGameController</c> represents the controller of the last minigame played.</value>
        MinigameController LastGameController { get; set; }

        /// <summary>
        /// Get the gui used.
        /// </summary>
        Gui Gui { get; }

        /// <value><c>Factory</c> represents the controller factory used.</value>
        ControllerFactory Factory { get; set; }

        /// <summary>
        /// This method adds an existing scene.
        /// </summary>
        /// <param name="scene">The scene to add.</param>
        void addScene(S scene);

        /// <summary>
        /// This method pops a scene from the scenes list.
        /// </summary>
        /// <returns>The popped scene.</returns>
        S popScene();

        /// <summary>
        /// This method starts the gui.
        /// </summary>
        void run();

        /// <summary>
        /// This method returns the list of all scenes.
        /// </summary>
        /// <returns>All the scenes.</returns>
        List<S> getScenes();
    }
}
