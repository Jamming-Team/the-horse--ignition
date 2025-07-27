using System;
using Alchemy.Inspector;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace XTools {
    [RequireComponent(typeof(Slider))]
    public class UIViewSlider : MonoBehaviour {
        [SerializeField] UIAudioSliderChanged.UIAudioSliders _sliderType;
        [SerializeField] bool _hasSounds;
        [SerializeField, ShowIf("_hasSounds")] SoundData _onValueChangedSoundData;
        
        [Inject] AudioManager _audioManager;
        [Inject] DataManagerBase _dataManager;
        Slider _sliderReference;

        float _timer;
        
        // CountdownTimer _soundCooldownTimer = new CountdownTimer(1f);

        void Awake() {
            _sliderReference = GetComponent<Slider>();
            var audioData = _dataManager.GetData<AudioDataSO>();
            SetValue(audioData);
        }

        void Update() {
            Debug.Log(_timer);
            if (_timer > 0)
                _timer -= Time.unscaledDeltaTime;
        }

        void OnEnable() {
            _sliderReference.onValueChanged.AddListener(delegate {
                RaiseUIAudioSliderEvent();
                if (_hasSounds && _timer <= 0) {
                    _audioManager.PlaySound(_onValueChangedSoundData);
                    _timer = 0.1f;
                }
            });
        }
        
        void OnDisable() {
            _sliderReference.onValueChanged.RemoveListener(delegate {
                RaiseUIAudioSliderEvent();
                if (_hasSounds && _timer <= 0) {
                    _audioManager.PlaySound(_onValueChangedSoundData);
                    _timer = 0.1f;
                }
            });
        }

        void RaiseUIAudioSliderEvent() {
            EventBus<UIAudioSliderChanged>.Raise(new UIAudioSliderChanged
            {
                audioSliderType = _sliderType,
                value = _sliderReference.value,
            });
        }
        

        public void SetValue(AudioDataSO audioData) {
            switch (_sliderType) {
                case UIAudioSliderChanged.UIAudioSliders.MusicVolume: {
                    _sliderReference.value = audioData.musicVolume;
                    break;
                }
                case UIAudioSliderChanged.UIAudioSliders.SfxVolume: {
                    _sliderReference.value = audioData.sfxVolume;
                    break;
                }
                case UIAudioSliderChanged.UIAudioSliders.UIVolume: {
                    _sliderReference.value = audioData.uiVolume;
                    break;
                }
            }
        }
    }
}