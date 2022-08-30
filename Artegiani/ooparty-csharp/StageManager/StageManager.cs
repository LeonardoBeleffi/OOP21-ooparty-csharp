using System;
using System.Collections.Generic;
using Application.Minigames.Common.Controller;
using ooparty_csharp.SceneHandler;

namespace Application.StageManager
{
    /// <summary>
    /// Implementation of <see cref="IStageManager{S}"/>.
    /// </summary>
    /// <typeparam name="S">The scenes of the stage.</typeparam>
    public class StageManager<S> : IStageManager<S>
    {
        private IMinigameController lastGameController;

        /// <summary>
        /// Builds a <see cref="StageManager{S}"/>
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="guiType">The gui class type.</param>
        /// <param name="sceneHandler">The scene handler</param>
        public StageManager(string title, Type guiType, ISceneHandler<S> sceneHandler)
        {
            SceneHandler = sceneHandler;
            LastGameController = null;
            SetGui(title, guiType);
        }

        /// <summary>
        /// Builds a <see cref="StageManager{S}"/> without gui.
        /// </summary>
        /// <param name="sceneHandler">The scene handler.</param>
        public StageManager(ISceneHandler<S> sceneHandler) : this("", null, sceneHandler)
        {
        }

        public IMinigameController LastGameController
        {
            get => lastGameController;
            set
            {
                if (value is IMinigameController)
                {
                    lastGameController = value;
                }
            }
        }

        public IGui Gui { get; private set; }

        public List<S> Scenes => throw new NotImplementedException();

        private ISceneHandler<S> SceneHandler { get; set; }

        public void AddScene(S scene)
        {
            SceneHandler.AddScene(scene);
        }

        public S PopScene()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method sets the gui using reflection.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="guiType">The class type of the gui.</param>
        private void SetGui(string title, Type guiType)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            }
            if (guiType is null)
            {
                throw new ArgumentNullException(nameof(guiType));
            }
            Gui = (IGui)Activator.CreateInstance(guiType, new object[] { title });
        }
    }
}
