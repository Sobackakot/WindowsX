using UnityEngine.EventSystems;

public  class DragWindow : DraggableItemBase, IPointerEnterHandler, IPointerExitHandler
{ 
    private void OnEnable()
    { 
        context.SetIsActive(true);
    }
    private void OnDisable()
    {
        context.SetIsActive(false); 
    }
}
