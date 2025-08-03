using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drag.MultipleItem   
{
    public class MultipleBeginDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        Canvas canvas;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
            canvas = GetComponentInParent<Canvas>();
        }
        public bool OnMultipleBeginDrag(PointerEventData eventData, DraggableItemBase currentDraggableItem)
        { 
            if (registry.selectedItems.Count > 1 && registry.selectedItems.Contains(currentDraggableItem))
            {
                registry?.ResetOffsetItems();
                CalculateOffsetItems(eventData);
                return true;
            }
            else return false;
        }
        private void CalculateOffsetItems(PointerEventData eventData)
        { 
            Vector2 cursorLocalPointOnCanvas;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out cursorLocalPointOnCanvas);
            foreach (var item in registry.selectedItems)
            {
                item.OnBeginDrag(eventData);
                Vector2 offset = (Vector2)item.rectTransform.anchoredPosition - cursorLocalPointOnCanvas;
                registry?.SetOffsetItem(item, offset);
               
            }
        }
    }
}


