using System;

namespace Horse {
    public class ForestModel {
        public Action TimeIsOut = delegate { };
        
        public float fillAmount => _currentTime / _maxTime;
        
        float _currentTime;
        float _maxTime;
        
        public ForestModel(float maxTime) {
            _maxTime = maxTime;
            _currentTime = 0f;
        }

        public void Update(float deltaTime) {
            _currentTime += deltaTime;

            if (_currentTime > _maxTime) {
                TimeIsOut.Invoke();
            }
            
        }
    }
}