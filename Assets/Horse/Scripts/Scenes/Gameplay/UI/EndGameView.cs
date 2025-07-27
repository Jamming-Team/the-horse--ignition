using System;
using TMPro;
using UnityEngine;

namespace Horse {
    public class EndGameView : MonoBehaviour {
        [SerializeField] TMP_Text _total;
        [SerializeField] TMP_Text _saved;
        [SerializeField] TMP_Text _eaten;
        [SerializeField] TMP_Text _resultText;

        void Awake() {
            GP_SceneManager.GameResults.GameResultsUpdated += OnGameResultsUpdated;
            GameEvents.GameIsOver += OnGameIsOver;
        }

        void OnDestroy() {
            GP_SceneManager.GameResults.GameResultsUpdated -= OnGameResultsUpdated;
        }

        void OnGameResultsUpdated(GP_SceneManager.GameResults obj) {
            _total.text = obj.animalsTotal.ToString();
            _saved.text = obj.animalsSaved.ToString();
            _eaten.text = obj.animalsEaten.ToString();
        }

        void OnGameIsOver(bool obj) {
            if (obj) {
                _resultText.text = "You saved extracted all of them";
            }
            else {
                _resultText.text = "Not everyone was saved";
            }
        }
    }
}