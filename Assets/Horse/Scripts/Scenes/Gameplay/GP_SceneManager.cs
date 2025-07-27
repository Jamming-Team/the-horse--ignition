using System;
using UnityEngine;
using XTools;
using XTools.SM.Iron;

namespace Horse {
    public class GP_SceneManager : SceneManagerBase<GP_State> {
        GameResults _gameResults = new GameResults();

        void Awake() {
            GameEvents.AnimalsProcessed += OnAnimalsProcessed;
            GameEvents.AnimalsSpawned += AnimalsSpawned;
        }

        void OnDestroy() {
            GameEvents.AnimalsProcessed -= OnAnimalsProcessed;
            GameEvents.AnimalsSpawned -= AnimalsSpawned;
        }
        
        void AnimalsSpawned(int obj) {
            _gameResults.AddUp(total: obj);
        }

        void OnAnimalsProcessed(AnimalProcessingResults obj) {
            _gameResults.AddUp(saved: obj.wereSaved, eaten: obj.wereEaten);
        }

        protected override void SetupStateMachine() {
            _stateMachine = new StateMachine(this);

            var tetrisState = states.Find(v => v is TetrisState) as TetrisState;
            var pauseState = states.Find(v => v is PauseState) as PauseState;
            var gp_settingsState = states.Find(v => v is GP_SettingsState) as GP_SettingsState;
            var transitionState = states.Find(v => v is TransitionState) as TransitionState;
            var endGameState = states.Find(v => v is EndGameState) as EndGameState;

            AtCompare(tetrisState, pauseState,
                new ActionPredicateCompare<XToolsEvents.UIButtonTypes>(ref XToolsEvents.UIButtonPressed,
                    XToolsEvents.UIButtonTypes.Pause));
            AtCompare(pauseState, tetrisState,
                new ActionPredicateCompare<XToolsEvents.UIButtonTypes>(ref XToolsEvents.UIButtonPressed,
                    XToolsEvents.UIButtonTypes.Back));
            AtCompare(pauseState, gp_settingsState,
                new ActionPredicateCompare<XToolsEvents.UIButtonTypes>(ref XToolsEvents.UIButtonPressed,
                    XToolsEvents.UIButtonTypes.Settings));
            AtCompare(gp_settingsState, pauseState,
                new ActionPredicateCompare<XToolsEvents.UIButtonTypes>(ref XToolsEvents.UIButtonPressed,
                    XToolsEvents.UIButtonTypes.Back));
            // AtCompare(transitionState, tetrisState,
            //     new ActionPredicateCompare<XToolsEvents.UIButtonTypes>(ref XToolsEvents.UIButtonPressed,
            //         XToolsEvents.UIButtonTypes.Back));

            AtActionWithData(tetrisState, endGameState, new ActionPredicateWithData<bool>(ref GameEvents.GameIsOver));
            AtActionWithData(tetrisState, transitionState,
                new ActionPredicateWithData<AnimalProcessingResults>(ref GameEvents.AnimalsProcessed));

            AtAction(transitionState, tetrisState, new ActionPredicate(ref GameEvents.TransitionComplete));

            _stateMachine.SetState(tetrisState);
        }

        public class GameResults {
            public static Action<GameResults> GameResultsUpdated = delegate { };

            public int animalsTotal = 0;
            public int animalsSaved = 0;
            public int animalsEaten = 0;

            public void AddUp(int? total = null, int? saved = null, int? eaten = null) {
                animalsTotal += total ?? 0;
                animalsSaved += saved ?? 0;
                animalsEaten += eaten ?? 0;
                GameResultsUpdated.Invoke(this);
            }
        }
    }
}