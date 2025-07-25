using System;
using Alchemy.Inspector;
// using EditorAttributes;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XTools {
    [RequireComponent(typeof(Button))]
    public class UIViewButton : MonoBehaviour, IPointerEnterHandler {
        [SerializeField] XToolsEvents.UIButtonTypes _buttonType;
        [SerializeField] bool _hasSounds;
        [SerializeField, ShowIf("_hasSounds")] SoundData _onHoverSoundData;
        [SerializeField, ShowIf("_hasSounds")] SoundData _onClickSoundData;

        [Inject] AudioManager _audioManager;
        Button _buttonReference;

        void Awake() {
            _buttonReference = GetComponent<Button>();
        }

        void OnEnable() {
            _buttonReference.onClick.AddListener(RaiseUIButtonEvent);
        }

        void OnDisable() {
            _buttonReference.onClick.RemoveListener(RaiseUIButtonEvent);
        }

        void RaiseUIButtonEvent() {
            // EventBus<UIButtonPressed>.Raise(new UIButtonPressed {
            //     buttonType = _buttonType,
            // });
            XToolsEvents.UIButtonPressed.Invoke(_buttonType);
            if (_hasSounds) _audioManager.PlaySound(_onClickSoundData);
        }

        public void OnPointerEnter(PointerEventData eventData) {
            if (_hasSounds) _audioManager.PlaySound(_onHoverSoundData);
        }
    }
}