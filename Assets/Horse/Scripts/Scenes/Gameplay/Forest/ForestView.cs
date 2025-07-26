using System;
using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class ForestView : MonoBehaviour {
        [SerializeField] GameObject _viewPartsRoot;

        List<ForestViewPart> _viewParts = new List<ForestViewPart>();
        int _curIndex;

        void Awake() {
            foreach (Transform child in _viewPartsRoot.transform) {
                _viewParts.Add(child.GetComponent<ForestViewPart>());
            }

            _curIndex = 0;
        }

        public void AdjustFillAmount(float amount) {
            // Debug.Log("Count: " + _viewParts.Count);
            // Debug.Log("this: " + _curIndex / (_viewParts.Count - 1) + "; amount:" + amount);
            var curViewAmount = Mathf.InverseLerp(0, _viewParts.Count - 1, _curIndex);
            if (curViewAmount <= amount) {
                _viewParts[_curIndex].Check();
                _curIndex++; 
            }
        }
    }
}