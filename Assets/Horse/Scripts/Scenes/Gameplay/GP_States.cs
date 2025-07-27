using System;
using Reflex.Extensions;
using UnityEngine;
using XTools;

namespace Horse {
    [Serializable]
    public abstract class GP_State : SceneStateBase {
    }

    [Serializable]
    public sealed class TetrisState : GP_State {
        public override void OnEnter() {
            base.OnEnter();
            Time.timeScale = 1;
        }
    }

    [Serializable]
    public sealed class PauseState : GP_State {
        SceneLoader _sceneLoader;

        public override void OnEnter() {
            base.OnEnter();
            Time.timeScale = 0;

            _sceneLoader = GameLoopCenter.Instance.gameObject.scene.GetSceneContainer().Resolve<SceneLoader>();
            XToolsEvents.UIButtonPressed += UIButtonPressed;
        }

        public override void OnExit() {
            base.OnExit();
            XToolsEvents.UIButtonPressed -= UIButtonPressed;
        }

        void UIButtonPressed(XToolsEvents.UIButtonTypes obj) {
            if (obj.Equals(XToolsEvents.UIButtonTypes.LoadMainMenu)) {
                _sceneLoader.TryLoadScene("MainMenu");
            }
        }
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
            // Debug.Log("Enter");
            _coreMB.StartCoroutine(TransitionManager.Instance.Transit());
        }
    }

    [Serializable]
    public sealed class EndGameState : GP_State {
        
        SceneLoader _sceneLoader;
        
        public override void OnEnter() {
            base.OnEnter();
            Time.timeScale = 0;

            _sceneLoader = GameLoopCenter.Instance.gameObject.scene.GetSceneContainer().Resolve<SceneLoader>();
            XToolsEvents.UIButtonPressed += UIButtonPressed;
        }

        public override void OnExit() {
            base.OnExit();
            XToolsEvents.UIButtonPressed -= UIButtonPressed;
        }

        void UIButtonPressed(XToolsEvents.UIButtonTypes obj) {
            if (obj.Equals(XToolsEvents.UIButtonTypes.LoadMainMenu)) {
                _sceneLoader.TryLoadScene("MainMenu");
            }
            else if (obj.Equals(XToolsEvents.UIButtonTypes.LoadGameplay)) {
                _sceneLoader.TryLoadScene("Gameplay");
            }
        }
    }
}