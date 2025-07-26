using System;
using System.Collections;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.Splines;
using XTools;

namespace Horse {
    public class TransitionManager : Singleton<TransitionManager> {
        const float HALF_RATIO = 0.5f;
        const float END_RATIO = 1f;

        [SerializeField] SplineContainer _road;
        [SerializeField] Transform _truck;
        [SerializeField] float _truckSpeed;

        [Inject] DataManager _dataManager;

        GameDataSO _gameData;
        float _curRatio = 0f;

        protected override void Awake() {
            base.Awake();
            // ServiceLocator.ForSceneOf(this).Register(this);
            _gameData = _dataManager.GetData<GameDataSO>();
            _curRatio = HALF_RATIO;
            AdjustTruck();
        }

        // void Update() {
        //     _curRatio = (_curRatio + Time.deltaTime) % 1;
        //     // _truck.position = _road.EvaluatePosition(_curRation);
        //     // _truck.forward = _road.EvaluateUpVector(_curRation);
        //     _road.Evaluate(_curRatio, out var position, out var tangent, out _);
        //
        //     _truck.position = position;
        //
        //     float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
        //     _truck.rotation = Quaternion.Euler(0f, 0f, angle);
        // }

        public IEnumerator Transit() {
            _curRatio = HALF_RATIO;

            while (_curRatio < END_RATIO) {
                _curRatio += Time.deltaTime * _truckSpeed;
                
                AdjustTruck();
                
                yield return null;
            }

            yield return new WaitForSeconds(_gameData.truckWaitTime);

            _curRatio = 0f;

            while (_curRatio < HALF_RATIO) {
                _curRatio += Time.deltaTime * _truckSpeed;
                
                AdjustTruck();

                yield return null;
            }

            GameEvents.TransitionComplete.Invoke();
        }

        public void AdjustTruck() {
            _road.Evaluate(_curRatio, out var position, out var tangent, out _);

            _truck.position = position;

            float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
            _truck.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}