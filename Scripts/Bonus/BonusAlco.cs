using Data;
using Services;
using UnityEngine;
using Zenject;

namespace Bonus
{
    public class BonusAlco : MonoBehaviour
    {
        private const string PLAYER = "Player";
        
        [SerializeField] private int _count = 2; 
        [SerializeField] private ParticleSystem _effect;
        
        private EventService _eventService;

        [Inject]
        public void Construct(EventService eventService)
        {
            _eventService = eventService;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.name is PLAYER)
            {
                _eventService.InvokeAlco(_count);
                Instantiate(_effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}