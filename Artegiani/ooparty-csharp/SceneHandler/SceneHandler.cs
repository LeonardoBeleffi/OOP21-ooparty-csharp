using System;
using System.Collections.Generic;

namespace ooparty_csharp.SceneHandler
{
    /// <summary>
    /// Implementation of <see cref="ISceneHandler{S}"/>
    /// </summary>
    /// <typeparam name="S">The scenes of the stage.</typeparam>
    public class SceneHandler<S> : ISceneHandler<S>
    {
        private readonly Stack<S> scenes;

        public SceneHandler()
        {
            scenes = new Stack<S>();
        }

        public Stack<S> Scenes => scenes;

        public S Scene
        {
            get => Scenes.Pop();
            set
            {
                if (value != null)
                {
                    Scenes.Push(value);
                }
            }
        }
    }
}
