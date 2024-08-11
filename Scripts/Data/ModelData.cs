using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ModelData", menuName = "Data/ModelData")]
    public class ModelData : ScriptableObject
    {
        public ModelType type;
        public GameObject Prefab;
    }
}