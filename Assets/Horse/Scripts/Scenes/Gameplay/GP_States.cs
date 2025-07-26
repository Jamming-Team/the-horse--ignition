using System;

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
    public sealed class IntermediateResultsState : GP_State {

    }
    
    [Serializable]
    public sealed class EndGameState : GP_State {

    }
}