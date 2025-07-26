using System;
using System.Collections.Generic;
using UnityEngine;
using XTools;

namespace Horse {
    public class MockTetris : MonoBehaviour {
        [SerializeField] List<AnimalContainer> _containers = new();

        void Awake() {
            XToolsEvents.UIButtonPressed += UIButtonPressed;
        }

        void OnDestroy() {
            XToolsEvents.UIButtonPressed -= UIButtonPressed;
        }

        void UIButtonPressed(XToolsEvents.UIButtonTypes obj) {
            if (obj == XToolsEvents.UIButtonTypes.Submit) {
                GameEvents.AnimalContainersSent.Invoke(_containers);
            }
        }
    }
}