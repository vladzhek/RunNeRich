﻿using Services;
using UI;
using Zenject;

namespace Infastructure
{
    public class LoadMenuState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        private StaticDataService _staticDataService;

        [Inject]
        private void Construct(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public LoadMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string scene)
        {
            InjectService.Instance.Inject(this);
            
            _sceneLoader.Load(scene, OnLoaded);
        }

        private void OnLoaded()
        {
            //TODO: Меню бесcмыслено для ТЗ
            _gameStateMachine.Enter<GameLoopState, string>("Game");
        }

        public void Exit()
        {

        }
    }
}