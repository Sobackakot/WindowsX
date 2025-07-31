using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemBase : MonoBehaviour, IDropHandler
{
    protected RegistrySelectableItems reg;
    protected RectTransform rectTransform;
    protected Transform targetContent;

    private void Awake()
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponentInChildren<HashContent>()?.transform;
    }
    public void OnDrop(PointerEventData eventData)
    { 
        Debug.Log(GetType().Name);
        if (reg.dropItems.Count > 1)
            MultipleDrop(targetContent);

        else if (reg.currentDraggableItem != null)
            SingleDrop(targetContent); 
    }
    private void SingleDrop(Transform trTarget)
    {
        DraggableItemBase item = reg.currentDraggableItem;
        Drop(item, trTarget);
    }


    private void MultipleDrop(Transform trTarget)
    {
        foreach (var item in reg.dropItems)
        {
            Drop(item, trTarget);
        }
        reg.dropItems.Clear();
    }
    private static void Drop(DraggableItemBase item, Transform trTarget)
    { 
        if (item == null || trTarget == null) return;
   
        item.accepted_Transform = trTarget;
        item?.transform.SetParent(trTarget);
        item?.context.LineDisable(item.line);
        item?.context.ResetBlocksRaycast(true, 1f, item.canvasGroup); 
    }
}
