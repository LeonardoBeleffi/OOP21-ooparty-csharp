using System;
using System.Collections.Generic;
using System.Reflection;
using Application.Minigames.Common.Controller;

namespace Application.StageManager
{
    public class StageManager<S> : IStageManager<S>
    {
        private readonly ISceneHandler<S> sceneHandler;

        public StageManager(string title, Type guiType, ISceneHandler<S> sceneHandler)
        {
            this.sceneHandler = sceneHandler;
            LastGameController = null;
            SetGui(title, guiType);
        }

        public IMinigameController LastGameController { get; set; }

        public IGui Gui { get; private set; }

        public IControllerFactory Factory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<S> Scenes => throw new NotImplementedException();

        public void AddScene(S scene)
        {
            throw new NotImplementedException();
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
            Gui = (IGui)Activator.CreateInstance(guiType, new object[] { title, this });
        }
    }
}
