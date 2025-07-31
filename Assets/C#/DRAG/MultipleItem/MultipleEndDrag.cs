using Drag.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using Drag.RegisterItem;

namespace Drag.MultipleItem
{
    public class MultipleEndDrag : MonoBehaviour
    {
        RegistrySelectableItems registry;
        private void Awake()
        {
            registry = FindObjectOfType<RegistrySelectableItems>();
        }
        public void OnMultipleEndDrag(PointerEventData eventData)
        {
            foreach (var item in registry.selectedItems)
            { 
                item.OnEndDrag(eventData);
                item.context.LineEnable(item.line);
            }
            registry?.ResetOffsetItems();
        }
    }
}