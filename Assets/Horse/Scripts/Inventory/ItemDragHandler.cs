using UnityEngine;
using UnityEngine.EventSystems;

namespace Horse.Inventory
{
    public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rt;
        private Canvas canvas;
        private InventoryGrid grid;
        private Vector2 originalPosition;
        private Transform originalParent;
        private bool isDraggingFromInventory = false;

        void Awake()
        {
            rt = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            grid = FindObjectOfType<InventoryGrid>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            originalPosition = rt.anchoredPosition;
            originalParent = rt.parent;
            
            // Проверяем, был ли предмет уже в инвентаре
            isDraggingFromInventory = (originalParent == grid.inventoryRoot);
            
            rt.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 pos);
            rt.anchoredPosition = pos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                grid.inventoryRoot as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPos);

            Vector2Int cellPos = grid.GetGridPosition(localPos);
            InventoryItem item = GetComponent<InventoryItem>();

            if (grid.CheckFit(cellPos, item.data))
            {
                grid.PlaceItem(item, cellPos); // Размещаем в инвентаре
            }
            else if (isDraggingFromInventory)
            {
                // Возвращаем на старое место, если не удалось перетащить в новое
                rt.SetParent(originalParent);
                rt.anchoredPosition = originalPosition;
            }
            else
            {
                // Если предмет не из инвентаря и не поместился — уничтожаем
                Destroy(item.gameObject);
            }
        }
    }
}
