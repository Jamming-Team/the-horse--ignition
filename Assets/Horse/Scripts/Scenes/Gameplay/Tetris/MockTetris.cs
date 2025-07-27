using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XTools;

namespace Horse {
    public class MockTetris : MonoBehaviour {
        
        [SerializeField] Inventory _inventory;
        [SerializeField] List<GameObject> _grids = new List<GameObject>();

        [SerializeField] GameObject _spawnerGrid;

        List<AnimalContainer> _containers = new();
        
        void Awake() {
            XToolsEvents.UIButtonPressed += UIButtonPressed;
        }

        void OnDestroy() {
            XToolsEvents.UIButtonPressed -= UIButtonPressed;
        }

        void UIButtonPressed(XToolsEvents.UIButtonTypes obj) {
            if (obj == XToolsEvents.UIButtonTypes.Submit) {
                _containers.Clear();
                foreach (var grid in _grids) {
                    var items = grid.GetComponentsInChildren<Item>();
                    var container = new AnimalContainer();
                    foreach (var item in items) {
                        container.animals.Add(item.data);
                        _inventory.RemoveItem(item);
                    }
                    _containers.Add(container);
                }
                
                GameEvents.AnimalContainersSent.Invoke(_containers);
                if (_spawnerGrid.transform.childCount == 0) {
                    GameEvents.GameIsOver.Invoke(true);
                }
            }
        }
    }
}