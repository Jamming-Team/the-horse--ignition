using System;
using System.Collections.Generic;
using UnityEngine;
using XTools.SM.Iron;

namespace Horse {
    [Serializable]
    public abstract class SceneStateBase : IState {
        public List<GameObject> views;

        public void OnEnter() {
            views.ForEach(view => view.SetActive(true));
        }

        public void OnExit() {
            views.ForEach(view => view.SetActive(false));
        }
    }
}