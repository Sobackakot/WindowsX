using UnityEngine.EventSystems;

public  class DragWindow : DraggableItemBase, IPointerEnterHandler, IPointerExitHandler
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        context.SetIsDraggableItem(true);
        context.SetHasHitPointCursor(true);
        context.ResetBlocksRaycast(false, 0.5f, canvasGroup);
        accepted_Transform = transform.parent;
        rectTransform?.SetParent(canvas.transform);
        rectTransform?.SetAsLastSibling();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        context.SetHasHitPointCursor(true);
        context.SetIsDraggableItem(true);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(false);
        context.SetIsDraggableItem(false);

        context.ResetBlocksRaycast(true, 1, canvasGroup);
        rectTransform?.SetParent(accepted_Transform);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        context.LineEnable(line);
        context.PointerEnter();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(false);
        context.LineDisable(line);
        context.PointerExit();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(true);
        context.LineEnable(line);
        context.PointerEnter(); 
    }

    public override void OnPointerDown(PointerEventData eventData)
    { 
    }

    public override void OnPointerUp(PointerEventData eventData)
    { 
    }
}
