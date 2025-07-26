using UnityEngine;

namespace Horse.Inventory
{
    // Assets → Create → Inventory → ItemData
    [CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Inventory/ItemData")]
    [System.Serializable]
    public class InventoryItemData : ScriptableObject
    {
        public string itemName;
        public int width = 1;
        public int height = 1;
        public Sprite icon;
    }
}
