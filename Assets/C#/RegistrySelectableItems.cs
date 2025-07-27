using Drag.SelectItem;
using System.Collections.Generic;
using UnityEngine;

namespace Drag.RegisterItem
{
    public class RegistrySelectableItems : MonoBehaviour
    { 
        public readonly List<DragBase> selectedItems = new();
        public readonly List<DragBase> dropItems = new();
        public readonly List<DragBase> draggableItems = new();
        public readonly Dictionary<DragBase, Vector2> itemsOffset = new();
        
        public DragBase currentDraggableItem { get; private set; }

        private SelectionFrame selection;

        private void Awake()
        {
            selection = GetComponent<SelectionFrame>();
            draggableItems.AddRange(GetComponentsInChildren<DragBase>(false));  
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
        public void SetCurrentItem(DragBase currentDraggableItem)
        {
            this.currentDraggableItem = currentDraggableItem;
        }
        public void FindCurrentDraggableItem()
        { 
            currentDraggableItem = null;
            foreach (var item in draggableItems)
            {
                if (item.context.HasHitPointCursor)
                {
                    currentDraggableItem = item;
                    Debug.Log("Set new currentItem " + item.gameObject.name);
                    break;
                }
            }
        }
        public void SetItem(DragBase item)
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

        public void SetOffsetItem(DragBase item, Vector2 offset)
        {
            itemsOffset[item] = offset;
        }
        public void ResetOffsetItems()
        {
            itemsOffset?.Clear();
        }
        public Vector2 GetOffsetItem(DragBase item)
        {
            return itemsOffset[item];
        }
    }
}