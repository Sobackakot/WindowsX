using Drag.Item;
using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DropBase : MonoBehaviour, IDropHandler
{
    protected RegistrySelectableItems reg;
    protected RectTransform rectTransform;
    protected Transform targetContent;


    public void OnDrop(PointerEventData eventData)
    { 
        if (reg.dropItems.Count > 1)
            MultipleDrop(targetContent);

        else if (reg.currentDraggableItem != null)
            SingleDrop(targetContent);
    }
    private void SingleDrop(Transform trTarget)
    {
        DraggableItem item = reg.currentDraggableItem;
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
    private static void Drop(DraggableItem item, Transform trTarget)
    {
        if (item == null || trTarget == null) return;

        item.accepted_Transform = trTarget;
        item?.transform.SetParent(trTarget);
        item?.context.LineDisable(item.line);
        item?.context.ResetBlocksRaycast(true, 1f, item.canvasGroup);
        Debug.Log("drop item " + item.gameObject.name + " " + item.context.IsActive);

        if (item.context.IsActive)
            item.enabled = false;
    }
}
