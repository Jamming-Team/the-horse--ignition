using System;
using Reflex.Attributes;
using UnityEngine;

namespace Horse {
    public class ForestController : MonoBehaviour {
        [SerializeField] ForestView _view;

        [Inject] DataManager _dataManager;

        ForestModel _model;
        bool _isActive;

        public void Awake() {
            var gameData = _dataManager.GetData<GameDataSO>();
            _model = new ForestModel(gameData.maxForestBurnTime);
            _model.TimeIsOut += OnTimeIsOut;
            _isActive = true;
        }

        public void OnDestroy() {
            _model.TimeIsOut -= OnTimeIsOut;
        }

        public void Update() {
            if (!_isActive)
                return;
            
            _model.Update(Time.deltaTime);
            _view.AdjustFillAmount(_model.fillAmount);
        }

        void OnTimeIsOut() {
            _isActive = false;
        }
    }
}