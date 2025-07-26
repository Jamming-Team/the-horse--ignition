using System;
using System.Collections.Generic;

namespace Horse {
    [Serializable]
    public class AnimalContainer {
        public List<Animal> animals;
        
        public List<AnimalData> ExtractData() {
            var result = new List<AnimalData>();

            
            foreach (var animal in animals) {
                result.Add(animal.data);
            }
            
            return result;
        }
    }
}