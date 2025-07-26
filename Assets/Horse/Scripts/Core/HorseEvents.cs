using System;
using System.Collections.Generic;

namespace Horse {
    public static class HorseEvents {

        public static Action<List<List<AnimalData>>> AnimalContainersSent = delegate {};
        public static Action<AnimalProcessingResults> AnimalsProcessed =  delegate {};
    }
}