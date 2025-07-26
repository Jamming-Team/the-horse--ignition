using System.Collections.Generic;
using UnityEngine;

namespace Horse {
    public class AnimalProcessingView : MonoBehaviour {
        [SerializeField] AnimalViewLogItem _logItemViewPrefab;
        [SerializeField] GameObject _logItemsViewRoot;

        List<AnimalViewLogItem> _shownLogItems = new List<AnimalViewLogItem>();
        
        public void FillView(List<AnimalEatingLog> logItems) {
            _shownLogItems.ForEach(Destroy);
            _shownLogItems.Clear();
            foreach (var logItem in logItems) {
                var item = Instantiate(_logItemViewPrefab, _logItemsViewRoot.transform);
                item.Initialize(logItem);
                _shownLogItems.Add(item);
            }
        }

    }
}