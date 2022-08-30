using System;
using System.Collections.Generic;

namespace ooparty_csharp.SceneHandler
{
    /// <summary>
    /// This interface models a scene handler.
    /// </summary>
    /// <typeparam name="S">The scenes of the stage.</typeparam>
    public interface ISceneHandler<S>
    {
        /// <summary>
	    /// <c>Scenes</c> gets the scenes list.
	    /// </summary>
        Stack<S> Scenes { get; }

        /// <summary>
	    /// <c>Scene</c> represents a scene of the scene list. It pops or adds a
        /// scene to the scenes list.
	    /// </summary>
        S Scene { get; set; }
    }
}