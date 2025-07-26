using UnityEngine;

namespace XTools.SM.Iron {
    public interface IState {

        void Init(MonoBehaviour core) {
            
        }
        
        void OnEnter() {
        }

        void Update() {
        }

        void FixedUpdate() {
        }

        void OnExit() {
        }
    }
}