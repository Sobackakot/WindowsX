using UnityEngine;
using UnityEngine.UI;

public class ItemStateContext 
{
    public bool HasHitPointCursor { get; private set; }
    public bool IsDraggableItem { get; private set; }
    public bool InSelectionFrame { get; private set; }
    public bool IsHasSlotParent { get; private set; }
    public bool IsActive { get; private set; } 

    public void SetHasHitPointCursor(bool isHit) => HasHitPointCursor = isHit;
    public void SetIsDraggableItem(bool isDrag) => IsDraggableItem = isDrag;
    public void SetInSelectionFrame(bool inFrame) => InSelectionFrame = inFrame;
    public void SetIsHasSlotParent(bool isHasSlot) => IsHasSlotParent = isHasSlot;
    public void SetIsActive(bool isActive) => IsActive = isActive;

    public void SetInFrame(Outline line)
    {
       SetInSelectionFrame(true);
       LineEnable(line);
    }
    public void ResetInFrame(Outline line)
    {
        SetInSelectionFrame(false);
        LineDisable(line);
    }
    public void LineEnable(Outline line)
    {
        line.enabled = true;
    }
    public void LineDisable(Outline line)
    {
        if (!InSelectionFrame)
            line.enabled = false;
    }
    public void PointerEnter()
    {
        SetHasHitPointCursor(true);
    }
    public void PointerExit()
    {
        SetHasHitPointCursor(false);
    }
    public void ResetBlocksRaycast(bool isBlock, float value, CanvasGroup canvasGroup)
    {
        canvasGroup.blocksRaycasts = isBlock;
        canvasGroup.alpha = value;
    }
}
