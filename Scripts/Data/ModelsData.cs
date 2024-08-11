using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ModelsData", menuName = "Data/ModelsData")]
    public class ModelsData : ScriptableObject
    {
        public List<ModelData> listModels;
    }
}