using UnityEngine;
using UnityEngine.UI;

namespace Horse {
    public class AnimalViewLogItem : MonoBehaviour {

        [SerializeField] Image _eater;
        [SerializeField] Image _prey;

        public void Initialize(AnimalEatingLog log) {
            _eater.sprite = log.eater.sprite;
            _prey.sprite = log.prey.sprite;
        }

        public void Break() {
            Destroy(gameObject);
        }

    }
}