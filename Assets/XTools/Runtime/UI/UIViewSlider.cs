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

        CountdownTimer _soundCooldownTimer = new(0.1f);

        void Awake() {
            _sliderReference = GetComponent<Slider>();
            var audioData = _dataManager.GetData<AudioDataSO>();
            SetValue(audioData);
        }
        
        void OnEnable() {
            _sliderReference.onValueChanged.AddListener(delegate {
                RaiseUIAudioSliderEvent();
                if (_hasSounds && _soundCooldownTimer.IsFinished) {
                    _audioManager.PlaySound(_onValueChangedSoundData);
                    _soundCooldownTimer.Start();
                }
            });
        }
        
        void OnDisable() {
            _sliderReference.onValueChanged.RemoveListener(delegate {
                RaiseUIAudioSliderEvent();
                if (_hasSounds && _soundCooldownTimer.IsFinished) {
                    _audioManager.PlaySound(_onValueChangedSoundData);
                    _soundCooldownTimer.Start();
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