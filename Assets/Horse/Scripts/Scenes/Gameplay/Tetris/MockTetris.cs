using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class MockTetris : MonoBehaviour {

        [SerializeField] List<AnimalContainer> _containers = new();
        
        

        void Start() {

            
            GameEvents.AnimalContainersSent.Invoke(_containers);
        }


    }
}