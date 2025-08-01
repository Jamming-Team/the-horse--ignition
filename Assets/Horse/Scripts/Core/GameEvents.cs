using System;
using System.Collections.Generic;

namespace Horse {
    public static class GameEvents {
        public static Action<int> AnimalsSpawned =  delegate {};
        
        public static Action<List<AnimalContainer>> AnimalContainersSent = delegate {};
        public static Action<AnimalProcessingResults> AnimalsProcessed =  delegate {};
        public static Action TransitionComplete = delegate { };
        
        public static Action<bool> GameIsOver = delegate {};
    }
}