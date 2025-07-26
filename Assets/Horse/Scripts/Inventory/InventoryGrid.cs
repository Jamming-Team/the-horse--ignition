using UnityEngine;

namespace Horse.Inventory
{
    public class InventoryGrid : MonoBehaviour
    {
        public int gridWidth = 4;
        public int gridHeight = 4;
        public float cellSize = 64f;
        public Transform inventoryRoot;

        private InventoryItem[,] gridArray;

        void Awake() {
            gridArray = new InventoryItem[gridWidth, gridHeight];
        }

        public Vector2Int GetGridPosition(Vector2 localPosition) {
            // localPosition - координаты относительно inventoryRoot
            int x = Mathf.FloorToInt(localPosition.x / cellSize);
            // инвертируем Y, т.к. в UI ось Y направлена вниз
            int y = Mathf.FloorToInt(-localPosition.y / cellSize);
    
            // Ограничиваем позицию в пределах сетки
            x = Mathf.Clamp(x, 0, gridWidth - 1);
            y = Mathf.Clamp(y, 0, gridHeight - 1);
    
            return new Vector2Int(x, y);
        }

        public bool CheckFit(Vector2Int pos, InventoryItemData data) {
            // Проверяем, не выходит ли предмет за границы
            if (pos.x < 0 || pos.y < 0 || pos.x + data.width > gridWidth || pos.y + data.height > gridHeight)
                return false;

            // Проверяем, свободны ли все нужные ячейки
            for (int x = 0; x < data.width; x++) 
            {
                for (int y = 0; y < data.height; y++) 
                {
                    if (gridArray[pos.x + x, pos.y + y] != null)
                        return false;
                }
            }
            return true;
        }

        public void RemoveItem(InventoryItem item)
        {
            if (item == null) return;

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (gridArray[x, y] == item)
                    {
                        gridArray[x, y] = null;
                    }
                }
            }
        }

        public void PlaceItem(InventoryItem item, Vector2Int pos)
        {
            // Если предмет уже в инвентаре — удаляем его из старой позиции
            if (item.transform.parent == inventoryRoot)
            {
                RemoveItem(item);
            }

            // Проверяем, что позиция свободна
            if (!CheckFit(pos, item.data))
            {
                Debug.LogWarning("The cell is busy");
                return;
            }

            // Занимаем ячейки
            for (int x = 0; x < item.data.width; x++)
            {
                for (int y = 0; y < item.data.height; y++)
                {
                    gridArray[pos.x + x, pos.y + y] = item;
                }
            }

            RectTransform rt = item.GetComponent<RectTransform>();
            rt.SetParent(inventoryRoot);
            rt.anchoredPosition = new Vector2(0, 1);
        }
    }
}
