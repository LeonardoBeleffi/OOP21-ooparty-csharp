using System;
using System.Collections.Generic;
using Application.Minigames.Common.Controller;

namespace Application.StageManager
{
    public class StageManager<S> : IStageManager<S>
    {
        public StageManager()
        {
        }

        public MinigameController LastGameController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGui Gui => throw new NotImplementedException();

        public ControllerFactory Factory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<S> Scenes => throw new NotImplementedException();

        MinigameController IStageManager<S>.LastGameController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}
