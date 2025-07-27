using Drag.Item;
using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drag.MultipleItem
{
    public class MultipleDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        Canvas canvas;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
            canvas = GetComponentInParent<Canvas>();
        }
        public void OnMultipleDrag(PointerEventData eventData)
        { 
            foreach (var item in registry.selectedItems)
            {
                if (!registry.itemsOffset.ContainsKey(item)) continue;
                item.rectTransform.anchoredPosition = GetPointLocalPosition(eventData, item);
            }
        }
        private Vector2 GetPointLocalPosition(PointerEventData eventData, DragBase item)
        {
            Vector2 newPos = eventData.position + registry.GetOffsetItem(item);
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform, newPos, eventData.pressEventCamera, out localPoint);
            return localPoint;
        }
    }
}