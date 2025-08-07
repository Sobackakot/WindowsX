using Drag.SelectItem;
using System.Collections.Generic;
using UnityEngine;

namespace Drag.RegisterItem
{
    public class RegistrySelectableItems : MonoBehaviour
    { 
        public  List<DraggableItemBase> selectedItems = new();
        public  List<DraggableItemBase> dropItems = new();
        public  List<DraggableItemBase> draggableItems = new();
        public readonly Dictionary<DraggableItemBase, Vector2> itemsOffset = new();
        
        public DraggableItemBase currentDraggableItem { get; private set; }

        private SelectionFrame selection;

        private void Awake()
        {
            selection = GetComponent<SelectionFrame>();
            draggableItems.AddRange(GetComponentsInChildren<DraggableItemBase>(false));  
        }
        private void OnEnable()
        {
            selection.OnAddSelectedItem += AddItemDropAndSelect;
            selection.OnResetSelectedItems += ResetItems;
        }
        private void OnDisable()
        {
            selection.OnAddSelectedItem -= AddItemDropAndSelect;
            selection.OnResetSelectedItems -= ResetItems;
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
        public void AddItemDrag(DraggableItemBase item)
        {
            if (!draggableItems.Contains(item))
                draggableItems?.Add(item);
            Debug.Log(item.gameObject.name);
        }
         
        public void AddItemDropAndSelect(DraggableItemBase item)
        {  
            if (item.gameObject.layer == 7  && !selectedItems.Contains(item))
            {
                Debug.Log(item.gameObject.name);
                selectedItems.Add(item);
                dropItems.Add(item); 
            } 
        }
        public void ResetItems()
        { 
            foreach (var item in selectedItems)
                item?.context.ResetInFrame(item.line);
            selectedItems?.Clear();
        }
        public void ResetDropItems()//----
        {
            foreach (var item in dropItems)
                item?.context.ResetInFrame(item.line);
            dropItems?.Clear();
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