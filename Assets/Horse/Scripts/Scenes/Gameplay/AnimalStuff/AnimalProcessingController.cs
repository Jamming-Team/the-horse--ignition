using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class AnimalProcessingController : MonoBehaviour {
        
        [SerializeField] AnimalProcessingView _view;
        
        AnimalProcessingModel _model;
        
        void Awake() {
            _model = new AnimalProcessingModel();
            GameEvents.AnimalContainersSent += AnimalContainersSent;
        }

        void OnDestroy() {
            GameEvents.AnimalContainersSent -= AnimalContainersSent;
        }

        void AnimalContainersSent(List<AnimalContainer> obj) {

            var totalCount = 0;
            var eatingLogs = new List<AnimalEatingLog>();
            
            foreach (var container in obj) {
                totalCount += container.animals.Count;
                _model.Process(ref eatingLogs, container.ExtractData());
            }

            var results = new AnimalProcessingResults {
                wereEaten =  eatingLogs.Count,
                wereSaved = totalCount -  eatingLogs.Count,
            };

            _view.FillView(eatingLogs);
            
            GameEvents.AnimalsProcessed.Invoke(results);
        }
    }

    public struct AnimalProcessingResults {
        public int wereSaved;
        public int wereEaten;
    }
}