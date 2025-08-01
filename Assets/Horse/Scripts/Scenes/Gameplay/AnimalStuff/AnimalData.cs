using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    [Serializable]
    public class AnimalData {
        public AnimalType type;
        public List<AnimalType> whoItEats;
        public Sprite sprite;
    }

    public enum AnimalType {
        Bear,
        barsuk,
        ris,
        jaba,
        mish,
        krolik,
        zmeya,
        nasekomoe,
        sova,
        yaitso,
        ej
    }
}