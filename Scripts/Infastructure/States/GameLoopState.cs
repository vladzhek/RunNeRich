using Data;
using Services;
using Zenject;

namespace Infastructure
{
    public class GameLoopState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private WindowsService _windowService;
        private EventService _eventService;
        
        [Inject]
        private void Construct(WindowsService windowService, EventService eventService)
        {
            _windowService = windowService;
            _eventService = eventService;
        }
        
        public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
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
            _windowService.OpenWindow(WindowType.Gameplay);
            _eventService.OnNextLevel += EndLevel;
        }

        private void EndLevel()
        {
            //TODO: ManagerLevel
        }

        public void Exit()
        {
            
        }
    }
}