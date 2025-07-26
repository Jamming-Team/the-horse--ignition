using System;
using UnityEngine;

namespace Horse {
    public class IntermediateResultsView : MonoBehaviour {

        [SerializeField] GameObject _viewItself;
        
        
        void Start() {
            GameEvents.AnimalsProcessed += OnAnimalsProcessed;
        }

        void OnDisable() {
            GameEvents.AnimalsProcessed -= OnAnimalsProcessed;
        }

        void OnAnimalsProcessed(AnimalProcessingResults obj) {
            
            _viewItself.SetActive(true);
            
        }

        public void CloseView() {
            _viewItself.SetActive(false);
        }
        

    }
}