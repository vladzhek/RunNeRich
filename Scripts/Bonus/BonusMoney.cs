using Data;
using Services;
using UnityEngine;
using Zenject;

namespace Bonus
{
    public class BonusMoney : MonoBehaviour
    {
        [SerializeField] private int _count = 2;
        [SerializeField] private ParticleSystem _effect;
        private const string PLAYER = "Player";
        private CurrencyService _currencyService;

        [Inject]
        public void Construct(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.name is PLAYER)
            {
                _currencyService.AddCurrency(CurrencyType.Soft, _count);
                Instantiate(_effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}