using UnityEngine;

namespace Horse {
    public class ForestViewPart : MonoBehaviour {

        [SerializeField] GameObject _fineForest;
        [SerializeField] GameObject _burnedForest;
        [SerializeField] GameObject _fire;

        public void Check() {
            
            _fineForest.SetActive(!_fineForest.activeSelf);
            _burnedForest.SetActive(!_burnedForest.activeSelf);
            _fire.SetActive(!_fire.activeSelf);
        }
        
    }
}