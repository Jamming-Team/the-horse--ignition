using System;
using System.Collections.Generic;
using UnityEngine;
using XTools;

namespace Horse {
    public class ForestView : MonoBehaviour {
        [SerializeField] GameObject _viewPartsRoot;
        [SerializeField] Transform _mask;
        [SerializeField] Transform _startMaskPos;
        [SerializeField] Transform _endMaskPos;

        List<GameObject> _fireParts = new List<GameObject>();
        int _curIndex;

        void Awake() {
            _viewPartsRoot.SetActive(true);
            foreach (var child in _viewPartsRoot.transform.Children()) {
                _fireParts.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }

            _curIndex = 0;
        }

        public void AdjustFillAmount(float amount) {
            // Debug.Log("Count: " + _viewParts.Count);
            // Debug.Log("this: " + _curIndex / (_viewParts.Count - 1) + "; amount:" + amount);
            var curViewAmount = Mathf.InverseLerp(0, _fireParts.Count - 1, _curIndex);
            if (curViewAmount <= amount) {
                _fireParts[_curIndex].gameObject.SetActive(true);
                _curIndex++;
            }
            
            _mask.position = Vector3.Lerp(_startMaskPos.position, _endMaskPos.position, curViewAmount);
        }
    }
}