using Drag.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using Drag.RegisterItem;

namespace Drag.SingleItem
{
    public class SingleDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
        }
        public void OnSingleDrag(PointerEventData eventData, DraggableItem currentDraggableItem)
        {
            currentDraggableItem?.OnDrag(eventData);
            return;
        }
    }
}