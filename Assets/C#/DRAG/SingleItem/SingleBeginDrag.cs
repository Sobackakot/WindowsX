using Drag.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using Drag.RegisterItem;

namespace Drag.SingleItem
{
    public class SingleBeginDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
        }
        public void OnSingleBeginDrag(PointerEventData eventData, DragBase currentDraggableItem)
        { 

            if (registry.selectedItems.Count <= 1 || !registry.selectedItems.Contains(currentDraggableItem))
            {
                registry?.ResetItems();
                currentDraggableItem?.OnBeginDrag(eventData);
            }
        }
    }
}