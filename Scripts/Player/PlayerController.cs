using System;
using Data;
using Services;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Slider = UnityEngine.UI.Slider;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private GameObject _currentModel;
        
        private ModelType _currentModelType = ModelType.Junior;
        public float speed = 5f; 
        public float moveSpeed = 3f;

        private bool IsMove;
        public bool IsBlockedRight {
            get => _isBlockedRight;
            set => _isBlockedRight = value;
        }

        public bool IsBlockedLeft {
            get => _isBlockedLeft;
            set => _isBlockedLeft = value;
        }

        private bool _isBlockedRight = false;
        private bool _isBlockedLeft = false;
        private Rigidbody rb;

        [Inject] private EventService _eventService;
        [Inject] private CurrencyService _currencyService;
        [Inject] private StaticDataService _staticData;
        [Inject] private WindowsService _windowsService;
        
        public float rotationSpeed = 150f;
        private Quaternion targetRotation;

        private void Start()
        {
            IsMove = true;
            rb = GetComponent<Rigidbody>();
            targetRotation = transform.rotation;
            
            _eventService.OnFinishLevel += EndLevel;
            _eventService.OnUpdateAlco += ReducingSliderBar;
            _currencyService.OnCollect += UpdateSliderBar;
        }
        
        private void Update()
        {
            if (IsMove)
            {
                MoveForward();
                HandleMovement();
            }
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        private void EndLevel()
        {
            //_windowsService.CloseWindow(WindowType.Gameplay);
            _windowsService.OpenWindow(WindowType.Finish);
            rb.velocity = Vector3.zero;
            IsMove = false;
        }

        private void UpdateSliderBar(CurrencyType type, int amount)
        {
            if (type is CurrencyType.Soft)
                _slider.value += amount;
            ChangeModel();
        }

        private void ReducingSliderBar(int amount)
        {
            _slider.value -= amount;
            _currencyService.SpendCurrency(CurrencyType.Soft, amount);
            ChangeModel();
        }
        private void ChangeModel()
        {
            if (_slider.value >= 0 && _slider.value < 30)
            {
                if(_currentModelType == ModelType.Junior) return;
                
                UpdateModel(ModelType.Junior);
            }
            else if (_slider.value >= 30 && _slider.value < 60)
            {
                if(_currentModelType == ModelType.Middle) return;
                
                UpdateModel(ModelType.Middle);
            }
            else if (_slider.value >= 60 && _slider.value < 90)
            {
                if(_currentModelType == ModelType.Rich) return;
                
                UpdateModel(ModelType.Rich);
            }
            else if (_slider.value >= 90)
            {
                if(_currentModelType == ModelType.OverRich) return;
                
                UpdateModel(ModelType.OverRich);
            }
        }

        private void UpdateModel(ModelType type)
        {
            Destroy(_currentModel);
            _currentModelType = type;
            _currentModel = Instantiate(_staticData.Models[type].Prefab, transform);
        }

        private void MoveForward()
        {
            rb.velocity = transform.forward * speed;
        }

        private void HandleMovement()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = Input.mousePosition;

                if (mousePosition.x < Screen.width / 2)
                {
                    MoveLeft();
                }
                else if (mousePosition.x > Screen.width / 2)
                {
                    MoveRight();
                }
            }
        }
        
        private void MoveLeft()
        {
            if(_isBlockedLeft) return;
            
            rb.velocity = transform.right * -moveSpeed + transform.forward * speed;
        }

        private void MoveRight()
        {
            if(_isBlockedRight) return;
            
            rb.velocity = transform.right * moveSpeed + transform.forward * speed;
        }
        
        public void TurnLeft()
        {
            // Задаем новую целевую ориентацию, добавляя 90 градусов по оси Y
            targetRotation *= Quaternion.Euler(0, 90, 0);
        }

        public void TurnRight()
        {
            // Задаем новую целевую ориентацию, вычитая 90 градусов по оси Y
            targetRotation *= Quaternion.Euler(0, -90, 0);
        }
    }
}