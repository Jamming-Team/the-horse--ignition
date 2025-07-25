using System;
using System.Collections.Generic;
using Alchemy.Serialization;
using UnityEngine;
using XTools;
using static XTools.XToolsEvents;
using XTools.SM.Iron;

namespace Horse {
    public abstract class SceneManagerBase<T> : MonoBehaviour {
        [SerializeReference] public List<T> states = new();

        protected StateMachine _stateMachine;
        
        void Start() {
            SetupStateMachine();
        }

        void Update() {
            _stateMachine.Update();
        }

        protected abstract void  SetupStateMachine();
        
        protected void At(IState from, IState to, ActionPredicateCompare<UIButtonTypes> condition) {
            _stateMachine.AddTransition(from, to, condition);
        }
    }
}