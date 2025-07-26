using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class AnimalProcessingController : MonoBehaviour {
        
        AnimalProcessingModel _model;
        
        void Awake() {
            HorseEvents.AnimalContainersSent += AnimalContainersSent;
        }

        void OnDestroy() {
            HorseEvents.AnimalContainersSent -= AnimalContainersSent;
        }

        void AnimalContainersSent(List<List<AnimalData>> obj) {

            var totalCount = 0;
            var eatingLogs = new List<AnimalEatingLog>();
            
            foreach (var container in obj) {
                totalCount += container.Count;
                _model.Process(ref eatingLogs, container);
            }

            var results = new AnimalProcessingResults {
                wereEaten =  eatingLogs.Count,
                wereSaved = totalCount -  eatingLogs.Count,
            };

            HorseEvents.AnimalsProcessed.Invoke(results);
            
        }
    }

    public struct AnimalProcessingResults {
        public int wereSaved;
        public int wereEaten;
    }
}