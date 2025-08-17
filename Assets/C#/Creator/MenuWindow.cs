using Drag.RegisterItem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : MonoBehaviour 
{ 

    public List<ItemData> items = new();
    public Dictionary<ItemType,ItemData> itemsType = new();
    private Transform mainPanelTrans;
    private RegistrySelectableItems registry;

    private DraggableItemBase currentItemData;
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
        OnMousePointerEnter();
    }
    private void OnDisable()
    { 
    }
 
    private void OnMousePointerEnter() 
    { 
        if (registry.currentDraggableItem != null)
        { 
            currentItemData = registry.currentDraggableItem; 
        }
    }
    public void CreateItem(ItemData itemData)
    {
        var newItemData = Instantiate(itemData);
        GameObject newItem = Instantiate(newItemData.prefabItem, mainPanelTrans.position, mainPanelTrans.rotation);
        newItem.transform.SetParent(mainPanelTrans);
        DraggableItemBase newDragItem = newItem.GetComponent<DraggableItemBase>(); 
        newDragItem.SetDataComponents(newItemData);
        newItemData?.SetNewId();
        registry?.AddNewItem(newDragItem, newItemData.id);
    }
    public void RemoveItem()
    {
        if (registry != null && currentItemData != null)
        { 
            registry.FindCurrentDraggableItem(); 
            registry.RemoveItem(currentItemData?.currentItemData.id);
            currentItemData = null;
            gameObject.SetActive(false);
        }
    }

    public void RenameItem()
    {
        if (registry != null && currentItemData != null)
        {
            currentItemData.GetComponent<ItemInteract>().inputField.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
   
}
