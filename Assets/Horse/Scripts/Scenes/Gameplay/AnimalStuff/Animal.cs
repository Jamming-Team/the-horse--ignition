using UnityEngine;

namespace Horse {
    public class Animal : MonoBehaviour {
        [SerializeField] AnimalData _data;
        public AnimalData data => _data;
        
        
    }
}