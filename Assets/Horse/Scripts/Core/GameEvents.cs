using System;
using System.Collections.Generic;

namespace Horse {
    public static class GameEvents {

        public static Action<List<AnimalContainer>> AnimalContainersSent = delegate {};
        public static Action<AnimalProcessingResults> AnimalsProcessed =  delegate {};
    }
}