using System;
using Infastructure;
using Services;
using TMPro;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace View
{
    public class GameplayView : MonoBehaviour
    {
        private const string LEVEL_ID = "level_id";
        
        [SerializeField] private TMP_Text _moneyCounter;
        [SerializeField] private TMP_Text _lvlText;
        [Inject] private CurrencyService _currencyService;

        private void Start()
        {
            InjectService.Instance.Inject(this);
            _lvlText.text = "level " + PlayerPrefs.GetInt(LEVEL_ID);
        }

        private void Update()
        {
            _moneyCounter.text = _currencyService.SoftCoins.ToString();
        }
    }
}