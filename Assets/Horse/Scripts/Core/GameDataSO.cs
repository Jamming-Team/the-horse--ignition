using System;
using System.Collections.Generic;
using Alchemy.Serialization;
using UnityEngine;

namespace Horse {
    [CreateAssetMenu(fileName = "GameDataSO", menuName = "Horse/GameDataSO", order = 0)]
    public class GameDataSO : ScriptableObject {

        public float maxForestBurnTime = 60f;

    }
    

}