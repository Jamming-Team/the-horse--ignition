using System;
using UnityEngine;
using UnityEngine.UI;

namespace Horse.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        public InventoryItemData data;
        public Image iconImage;
        public RectTransform rectTransform;

        public void SetData(InventoryItemData itemData) {
            data = itemData;
            iconImage.sprite = data.icon;
        
            // cellSize из InventoryGrid
            InventoryGrid grid = FindObjectOfType<InventoryGrid>();
            if (grid != null)
            {
                rectTransform.sizeDelta = new Vector2(
                    data.width * grid.cellSize,
                    data.height * grid.cellSize
                );
            }
            else
            {
                Debug.LogError("InventoryGrid is not found!");
            }
        }

        private void Start()
        {
            SetData(data);
        }
    }
}
