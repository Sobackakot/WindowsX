using Drag.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using Drag.RegisterItem;

namespace Drag.SingleItem
{
    public class SingleEndDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
        }
        public void OnSingleEndDrag(PointerEventData eventData, DraggableItem currentDraggableItem)
        {
            currentDraggableItem?.OnEndDrag(eventData);
            registry?.ResetDropItems();
        }
    }
}