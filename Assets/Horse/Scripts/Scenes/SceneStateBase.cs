using System;
using System.Collections.Generic;
using UnityEngine;
using XTools.SM.Iron;

namespace Horse {
    [Serializable]
    public abstract class SceneStateBase : IState {
        public List<GameObject> views;
        protected MonoBehaviour _coreMB;

        public virtual void Init(MonoBehaviour core) {
            _coreMB =  core;
        }

        public virtual void OnEnter() {
            views.ForEach(view => view.SetActive(true));
        }

        public virtual void OnExit() {
            views.ForEach(view => view.SetActive(false));
        }
    }
}