using Infastructure;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View
{
    public class FinishView : MonoBehaviour
    {
        private const string LEVEL_ID = "level_id";
        [SerializeField] private Button _nextLevel;
        [Inject] private EventService _eventService;

        private void Start()
        {
            InjectService.Instance.Inject(this);
            _nextLevel.onClick.AddListener(NextLevel);
        }

        private void NextLevel()
        {
            _eventService.InvokeNextLevel();
            var level_id = PlayerPrefs.GetInt(LEVEL_ID);
            PlayerPrefs.SetInt(LEVEL_ID, level_id++);
            
        }
    }
}