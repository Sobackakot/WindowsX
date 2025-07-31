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
            Vector2 currentCursorLocalPointOnCanvas;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out currentCursorLocalPointOnCanvas);
            foreach (var item in registry.selectedItems)
            {
                if (!registry.itemsOffset.ContainsKey(item)) continue;
                item.rectTransform.anchoredPosition = currentCursorLocalPointOnCanvas + registry.GetOffsetItem(item);
            }
        } 
    }
}