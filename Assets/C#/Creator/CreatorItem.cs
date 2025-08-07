using Drag.RegisterItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorItem : MonoBehaviour
{ 
    public List<ItemData> items = new();
    public Dictionary<ItemType,ItemData> itemsType = new();
    private Transform mainPanelTrans;
    private RegistrySelectableItems registry;
    private void Awake()
    { 
        foreach (var item in items)
        {
            if(!itemsType.ContainsKey(item.itemType))
                itemsType.Add(item.itemType, item);
        }
        registry = FindObjectOfType<RegistrySelectableItems>();
    }
    private void OnEnable()
    {
        mainPanelTrans = FindObjectOfType<HashDropContentOnPanel>(mainPanelTrans).transform;
    }
    public void CreateItem(ItemData item)
    {
        GameObject newItem = Instantiate(item.prefabItem, mainPanelTrans.position, mainPanelTrans.rotation);
        newItem.transform.SetParent(mainPanelTrans);
        DraggableItemBase newDragItem = newItem.GetComponent<DraggableItemBase>();

        registry?.AddItemDrag(newDragItem);
        registry?.AddItemDropAndSelect(newDragItem);
    }
    public void RemoveItem()
    {

    }
  
    public void RenameItem()
    {

    } 
}
