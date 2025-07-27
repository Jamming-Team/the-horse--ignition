using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class AnimalProcessingView : MonoBehaviour {
        [SerializeField] AnimalViewLogItem _logItemViewPrefab;
        [SerializeField] GameObject _logItemsViewRoot;

        [SerializeField] GameObject _noOneText;
        [SerializeField] GameObject _finalView;

        List<AnimalViewLogItem> _shownLogItems = new List<AnimalViewLogItem>();

        public void FillView(List<AnimalEatingLog> logItems) {
            foreach (var item in _shownLogItems.ToArray()) {
                item.Break();
            }

            _shownLogItems.Clear();

            _noOneText.SetActive(!(logItems.Count > 0));
            _finalView.SetActive(logItems.Count > 0);
            
            foreach (var logItem in logItems) {
                var item = Instantiate(_logItemViewPrefab, _logItemsViewRoot.transform);
                item.Initialize(logItem);
                _shownLogItems.Add(item);
            }
        }
    }
}