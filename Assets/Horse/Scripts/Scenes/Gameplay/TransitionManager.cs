using System;
using UnityEngine;
using UnityEngine.Splines;

namespace Horse {
    public class TransitionManager : MonoBehaviour {

        [SerializeField] SplineContainer _road;
        [SerializeField] Transform _truck;

        float _curRation = 0f;
        
        void Update() {
            _curRation = (_curRation + Time.deltaTime) % 1;
            // _truck.position = _road.EvaluatePosition(_curRation);
            // _truck.forward = _road.EvaluateUpVector(_curRation);
            _road.Evaluate(_curRation, out var position, out var tangent, out _);
            
            _truck.position =  position;
            
            float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
            _truck.rotation = Quaternion.Euler(0f, 0f, angle);

        }
    }
}