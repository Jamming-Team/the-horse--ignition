using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class AnimalProcessingModel {

        public void Process(ref List<AnimalEatingLog> eatingLogs, List<AnimalData> animalDatas) {
            
            foreach (var potentialEater in animalDatas.ToArray()) {
                if (potentialEater == null)
                    continue;
                
                foreach (var potentialPrey in animalDatas.ToArray()) {
                    if (potentialPrey == null)
                        continue;
                    
                    bool canEat = potentialEater.whoItEats.Contains(potentialPrey.type);
                    if (canEat) {
                        eatingLogs.Add( new AnimalEatingLog()
                        {
                            eater = potentialEater,
                            prey = potentialPrey,
                        });

                        animalDatas.Remove(potentialPrey);
                    }
                }
            }
            
        }
    }

    public struct AnimalEatingLog {
        public AnimalData eater;
        public AnimalData prey;
    }
}