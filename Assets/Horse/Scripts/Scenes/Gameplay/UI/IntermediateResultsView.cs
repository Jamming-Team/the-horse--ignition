using System;
using Reflex.Attributes;
using UnityEngine;
using XTools;

namespace Horse {
    public class IntermediateResultsView : MonoBehaviour {

        [SerializeField] GameObject _viewItself;
        [SerializeField] SoundData _showTheListSound;
        
        [Inject] AudioManager _audioManager;
        
        
        void Start() {
            GameEvents.AnimalsProcessed += OnAnimalsProcessed;
        }

        void OnDisable() {
            GameEvents.AnimalsProcessed -= OnAnimalsProcessed;
        }

        void OnAnimalsProcessed(AnimalProcessingResults obj) {
            
            _viewItself.SetActive(true);
            _audioManager.PlaySound(_showTheListSound);
        }

        public void CloseView() {
            _viewItself.SetActive(false);
        }
        

    }
}