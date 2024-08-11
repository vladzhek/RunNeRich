using Data;
using Services;
using UnityEngine;
using Zenject;

namespace Bonus
{
    public class FinishLevel : MonoBehaviour
    {
        private const string PLAYER = "Player";
        
        private EventService _eventService;
        private WindowsService _windowsService;

        [Inject]
        public void Construct(EventService eventService, WindowsService windowsService)
        {
            _eventService = eventService;
            _windowsService = windowsService;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.name is PLAYER)
            {
                _eventService.InvokeFinishLevel();
                _windowsService.OpenWindow(WindowType.Finish);
            }
        }
    }
}