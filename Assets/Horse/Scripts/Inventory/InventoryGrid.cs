using UnityEngine;

namespace Horse.Inventory
{
    public class InventoryGrid : MonoBehaviour
    {
        public int gridWidth = 5;
        public int gridHeight = 5;
        public float cellSize = 64f;
        public Transform inventoryRoot;

        private InventoryItem[,] gridArray;

        void Awake() {
            gridArray = new InventoryItem[gridWidth, gridHeight];
        }

        public Vector2Int GetGridPosition(Vector2 localPosition) {
            int x = Mathf.FloorToInt(localPosition.x / cellSize);
            int y = Mathf.FloorToInt(-localPosition.y / cellSize);
            return new Vector2Int(x, y);
        }

        public bool CheckFit(Vector2Int pos, InventoryItemData data) {
            if (pos.x < 0 || pos.y < 0 || pos.x + data.width > gridWidth || pos.y + data.height > gridHeight)
                return false;

            for (int x = 0; x < data.width; x++) {
                for (int y = 0; y < data.height; y++) {
                    if (gridArray[pos.x + x, pos.y + y] != null)
                        return false;
                }
            }

            return true;
        }

        public void PlaceItem(InventoryItem item, Vector2Int pos) {
            for (int x = 0; x < item.data.width; x++) {
                for (int y = 0; y < item.data.height; y++) {
                    gridArray[pos.x + x, pos.y + y] = item;
                }
            }

            RectTransform rt = item.GetComponent<RectTransform>();
            rt.SetParent(inventoryRoot);
            rt.anchoredPosition = new Vector2(pos.x * cellSize, -pos.y * cellSize);
        }
    }
}
