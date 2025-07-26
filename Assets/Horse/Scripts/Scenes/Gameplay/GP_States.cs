using System;
using UnityEngine;
using XTools;

namespace Horse {
    [Serializable]
    public abstract class GP_State : SceneStateBase {

    }
    
    [Serializable]
    public sealed class TetrisState : GP_State {

    }
    
    [Serializable]
    public sealed class PauseState : GP_State {

    }
    
    [Serializable]
    public sealed class GP_SettingsState : GP_State {

    }
    
    [Serializable]
    public sealed class TransitionState : GP_State {

        // TransitionManager _transitionManager;

        public override void Init(MonoBehaviour core) {
            base.Init(core);
            // ServiceLocator.For(_coreMB).Get(out _transitionManager);
        }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Enter");
            _coreMB.StartCoroutine(TransitionManager.Instance.Transit());
        }
    }
    
    [Serializable]
    public sealed class EndGameState : GP_State {

    }
}