using Infastructure.Services;
using Services;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class BootstrapState : IState
    {
        private const string Bootstrap = "Bootstrap";
        private const string LEVEL_ID = "level_id";
        private readonly GameStateMachine _stateMachine;
        
        private SceneLoader _sceneLoader;
        [Inject] private StaticDataService _staticDataService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            InjectService.Instance.Inject(this);

            RegisterServices();
            _sceneLoader.Load(Bootstrap, onLoaded: EnterLoadLevel);
            PlayerPrefs.SetInt(LEVEL_ID, 1);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadMenuState, string>("Menu");
        
        private void RegisterServices()
        {
            _staticDataService.Load();
            //TODO: ProgressService
        }

        public void Exit()
        {
            
        }
    }
}