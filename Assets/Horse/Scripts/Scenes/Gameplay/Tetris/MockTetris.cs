using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class MockTetris : MonoBehaviour {
        
        [SerializeField] List<List<Animal>> _containers = new List<List<Animal>>();
        
        [SerializeField] List<Animal> _animals = new List<Animal>();
        [SerializeField] List<Animal> _animals2 = new List<Animal>();
        [SerializeField] List<Animal> _animals3 = new List<Animal>();
        
        

        void Start() {
            _containers.Add(_animals);
            _containers.Add(_animals2);
            _containers.Add(_animals3);
            
            GameEvents.AnimalContainersSent.Invoke(Extract(_containers));
        }

        public List<List<AnimalData>> Extract(List<List<Animal>> containers) {
            var result = new List<List<AnimalData>>();

            foreach (var container in containers) {
                var refinedContainer = new List<AnimalData>();
                foreach (var animal in container) {
                    refinedContainer.Add(animal.data);
                }
                result.Add(refinedContainer);
            }
            
            return result;
        }
    }
}