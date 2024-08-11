using System;

namespace Services
{
    public class EventService
    {
        public event Action<int> OnUpdateAlco;
        public event Action OnFinishLevel;
        public event Action OnNextLevel;

        public void InvokeAlco(int amount)
        {
            OnUpdateAlco?.Invoke(amount);
        }
        
        public void InvokeFinishLevel()
        {
            OnFinishLevel?.Invoke();
        }

        public void InvokeNextLevel()
        {
            OnNextLevel?.Invoke();
        }
    }
}