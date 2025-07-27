using System.Collections.Generic;
using UnityEngine;
using Drag.Item;
using Drag.SelectItem;

namespace Drag.RegisterItem
{
    public class RegistrySelectableItems : MonoBehaviour
    { 
        public readonly List<DraggableItem> selectedItems = new();
        public readonly List<DraggableItem> dropItems = new();
        public readonly List<DraggableItem> draggableItems = new();
        public readonly Dictionary<DraggableItem, Vector2> itemsOffset = new();
        
        public  DraggableItem currentDraggableItem { get; private set; }

        private SelectionFrame selection;

        private void Awake()
        {
            selection = GetComponent<SelectionFrame>();
            draggableItems.AddRange(GetComponentsInChildren<DraggableItem>(false));  
        }
        private void OnEnable()
        {
            selection.OnAddSelectedItem += SetItem;
            selection.OnResetSelectedItems += ResetItems;
        }
        private void OnDisable()
        {
            selection.OnAddSelectedItem -= SetItem;
            selection.OnResetSelectedItems -= ResetItems;
        }
        public void SetCurrentDraggableItem()
        { 
            currentDraggableItem = null;
            foreach (var item in draggableItems)
            {
                if (item.context.HasHitPointCursor && item.gameObject.layer == 7)
                {
                    currentDraggableItem = item; 
                    break;
                }
            }
        }
        public void SetItem(DraggableItem item)
        {
            selectedItems.Add(item);  
            if (item.gameObject.layer == 7)
            { 
                dropItems.Add(item); 
            }
               
        }
        public void ResetItems()
        {
            foreach (var item in selectedItems)
                item?.context.ResetInFrame(item.line);
            selectedItems?.Clear();
        }
        public void ResetDropItems()
        {
            foreach (var item in dropItems)
                item?.context.ResetInFrame(item.line);
            dropItems?.Clear();
        }

        public void SetOffsetItem(DraggableItem item, Vector2 offset)
        {
            itemsOffset[item] = offset;
        }
        public void ResetOffsetItems()
        {
            itemsOffset?.Clear();
        }
        public Vector2 GetOffsetItem(DraggableItem item)
        {
            return itemsOffset[item];
        }
    }
}