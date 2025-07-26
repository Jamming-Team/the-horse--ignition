using System;
using UnityEngine;
using UnityEngine.UI;

namespace Horse.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        const int SPRITE_SIZE = 64; // for example
        
        public InventoryItemData data;
        public Image iconImage;
        public RectTransform rectTransform;

        public void SetData(InventoryItemData itemData) {
            data = itemData;
            iconImage.sprite = data.icon;
            rectTransform.sizeDelta = new Vector2(data.width * SPRITE_SIZE, data.height * SPRITE_SIZE);
        }

        private void Start()
        {
            SetData(data);
        }
    }
}
