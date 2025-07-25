using System;
using System.Collections.Generic;
using Alchemy.Serialization;
using UnityEngine;
using XTools;
using static XTools.XToolsEvents;
using XTools.SM.Iron;

namespace Horse {
    public class MM_SceneManager : SceneManagerBase<SceneStateBase> {
        
        protected override void SetupStateMachine() {
            _stateMachine = new StateMachine();
        
            var mainViewState = states.Find(v => v is MainViewState) as MainViewState;
            var settingsState = states.Find(v => v is SettingsState) as SettingsState;
            var authorsState = states.Find(v => v is AuthorsState) as AuthorsState;
        
            At(mainViewState, settingsState,
                new ActionPredicateCompare<UIButtonTypes>(ref XToolsEvents.UIButtonPressed, UIButtonTypes.Settings));
            At(mainViewState, authorsState,
                new ActionPredicateCompare<UIButtonTypes>(ref XToolsEvents.UIButtonPressed, UIButtonTypes.Authors));
            At(settingsState, mainViewState,
                new ActionPredicateCompare<UIButtonTypes>(ref XToolsEvents.UIButtonPressed, UIButtonTypes.Back));
            At(authorsState, mainViewState,
                new ActionPredicateCompare<UIButtonTypes>(ref XToolsEvents.UIButtonPressed, UIButtonTypes.Back));
        
            _stateMachine.SetState(mainViewState);
        }
        
        
    }
}