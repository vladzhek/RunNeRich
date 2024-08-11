using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Services
{
    public class StaticDataService
    {
        public Dictionary<WindowType, WindowData> Windows = new();
        public Dictionary<ModelType, ModelData> Models = new();
        
        public void Load()
        {
            LoadData();
        }

        private void LoadData()
        {
            LoadWindows();
            LoadModels();
        }
        
        private void LoadWindows()
        {
            var data = Resources.Load<AllWindowData>("Configs/AllWindowData");
            foreach (var window in data.Windows)
            {
                Windows.Add(window.Type, window);
            }
        }
        
        private void LoadModels()
        {
            var data = Resources.Load<ModelsData>("Configs/ModelsData");
            foreach (var value in data.listModels)
            {
                Models.Add(value.type, value);
            }
        }
    }
}