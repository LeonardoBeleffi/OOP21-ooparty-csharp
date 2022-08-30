using System;
using System.Collections.Generic;

namespace Application.StageManager
{
    /// <summary>
    /// This interface models a scene handler.
    /// </summary>
    /// <typeparam name="S">The scenes of the stage.</typeparam>
    public interface ISceneHandler<S>
    {
        /// <summary>
	    /// <c>LastSceneIndex</c> gets the index of the last scene added to the scenes list.
	    /// </summary>
        int LastSceneIndex { get; }

        /// <summary>
	    /// <c>Scenes</c> gets the scenes list.
	    /// </summary>
        List<S> Scenes { get; }

        /// <summary>
	    /// <c>Scene</c> represents a scene of the scene list.
	    /// </summary>
        S Scene { get; set; }

        /// <summary>
        /// This method adds a scene to the scenes list.
        /// </summary>
        /// <param name="scene">The scene to add.</param>
        void AddScene(S scene);

        /// <summary>
        /// This method adds a scene to the scenes list.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">If the scenes list is empty.</exception>
        /// <returns>The last added scene.</returns>
        S PopScene();
    }
}