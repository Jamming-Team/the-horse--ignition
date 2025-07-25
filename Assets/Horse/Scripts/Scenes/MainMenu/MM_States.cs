using System;
using System.Collections.Generic;
using UnityEngine;
using XTools.SM.Iron;

namespace Horse {
    
    // [Serializable]
    public abstract class MM_State : SceneStateBase {

    }
    
    [Serializable]
    public sealed class MainViewState : MM_State {

    }

    [Serializable]
    public sealed class SettingsState : MM_State {

    }
    
    [Serializable]
    public sealed class AuthorsState : MM_State {

    }
}