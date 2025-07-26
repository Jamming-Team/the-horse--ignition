using System;
using System.Collections.Generic;
using Reflex.Attributes;
using Reflex.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using XTools;
using XTools.SM.Iron;

namespace Horse {
    
    // [Serializable]
    public abstract class MM_State : SceneStateBase {

    }
    
    [Serializable]
    public sealed class MainViewState : MM_State {

        SceneLoader _sceneLoader;
        
        public override void OnEnter() {
            base.OnEnter();
            _sceneLoader = GameLoopCenter.Instance.gameObject.scene.GetSceneContainer().Resolve<SceneLoader>();
            XToolsEvents.UIButtonPressed += UIButtonPressed;
        }

        public override void OnExit() {
            base.OnExit();
            XToolsEvents.UIButtonPressed -= UIButtonPressed;
            
        }

        void UIButtonPressed(XToolsEvents.UIButtonTypes obj) {
            if (obj.Equals(XToolsEvents.UIButtonTypes.LoadGameplay)) {
                _sceneLoader.TryLoadScene("Gameplay");
            }
        }
    }

    [Serializable]
    public sealed class SettingsState : MM_State {

    }
    
    [Serializable]
    public sealed class AuthorsState : MM_State {

    }
}