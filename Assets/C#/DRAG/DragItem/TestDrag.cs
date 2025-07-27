using Drag.Item;
using UnityEngine.EventSystems;


public class TestDrag : DragBase, IPointerEnterHandler, IPointerExitHandler,  IDragHandler, IBeginDragHandler, IEndDragHandler
{
    DraggableItem drag;
    private void OnEnable()
    {
        drag = GetComponent<DraggableItem>();
        context.SetIsActive(true);
    }
    private void OnDisable()
    {
        context.SetIsActive(false);
        if (drag == null) return;
        drag.enabled = true;
    }
}
