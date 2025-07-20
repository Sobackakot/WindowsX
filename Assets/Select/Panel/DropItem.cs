using Drag.Item;
using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    private RegistrySelectableItems registry;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        registry = FindObjectOfType<RegistrySelectableItems>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        registry.SetCurrentDraggableItem();
        DraggableItem item = registry.currentDraggableItem; // null


        Transform target = rectTransform.GetComponentInChildren<ContentWindow>()?.transform;
       
        if (item != null && target != null)
        {
            item.accepted_Transform = target;
            item?.transform.SetParent(target);  
            item?.rectTransform.SetAsLastSibling();
            item?.LineDisable();
            Debug.Log("Drop item");
        }
    }
}
