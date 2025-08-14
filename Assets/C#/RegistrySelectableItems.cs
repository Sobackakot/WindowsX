using Drag.SelectItem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Drag.RegisterItem
{
    public class RegistrySelectableItems : MonoBehaviour
    { 
        public Dictionary<string,DraggableItemBase> itemsId = new();
        public  List<DraggableItemBase> selectedItems = new();
        public  List<DraggableItemBase> dropItems = new();
        public  List<DraggableItemBase> draggableItems = new();
        public readonly Dictionary<DraggableItemBase, Vector2> itemsOffset = new();
         
        public DraggableItemBase currentDraggableItem;

        private SelectionFrame selection;

        private void Awake()
        {
            selection = GetComponent<SelectionFrame>();
            draggableItems.AddRange(GetComponentsInChildren<DraggableItemBase>(false));  
        }
        private void OnEnable()
        {
            selection.OnAddSelectedItem += AddItemDropAndSelect;
            selection.OnResetSelectedItems += ResetSelectedItems;
        }
        private void OnDisable()
        {
            selection.OnAddSelectedItem -= AddItemDropAndSelect;
            selection.OnResetSelectedItems -= ResetSelectedItems;
        }
        public void SetCurrentItem(DraggableItemBase currentDraggableItem)
        {
            currentDraggableItem.context.SetHasHitPointCursor(true);
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
                    break;
                }
            }
        }
        public void AddNewItem(DraggableItemBase item, string id)
        {
            Debug.Log( id);
            if (!itemsId.ContainsKey(id))
            { 
                itemsId.Add(id, item);
                AddItemDrag(item);
                AddItemDropAndSelect(item);
                Debug.Log("add " + id);
            }
        } 
        public void AddItemDrag(DraggableItemBase item)
        {
            if (!draggableItems.Contains(item))
                draggableItems?.Add(item); 
        }
         
        public void AddItemDropAndSelect(DraggableItemBase item)
        {  
            if (item.gameObject.layer == 7  && !selectedItems.Contains(item))
            { 
                selectedItems.Add(item);
                dropItems.Add(item); 
            } 
        }
        public void RemoveItem(string id)
        {
            if(itemsId.TryGetValue(id, out var item))
            {
                Debug.Log("remove");
                Destroy(item.gameObject);
                itemsId?.Remove(id);
                draggableItems?.Remove(item);
                dropItems?.Remove(item);
            }
        }
    
        public void ResetDropItems() 
        {
            foreach (var item in dropItems)
                item?.context.ResetInFrame(item.line);
            dropItems?.Clear();
        }
        public void ResetDragableItems()
        {
            foreach (var item in draggableItems)
                item?.context.ResetInFrame(item.line);
            draggableItems?.Clear();
        }
        public void ResetSelectedItems()
        {
            foreach (var item in selectedItems)
                item?.context.ResetInFrame(item.line);
            selectedItems?.Clear();
        }
        public void SetOffsetItem(DraggableItemBase item, Vector2 offset)
        {
            itemsOffset[item] = offset;
        }
        public void ResetOffsetItems()
        {
            itemsOffset?.Clear();
        }
        public Vector2 GetOffsetItem(DraggableItemBase item)
        {
            return itemsOffset[item];
        }
    }
}