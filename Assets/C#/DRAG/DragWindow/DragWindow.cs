using UnityEngine.EventSystems;

public  class DragWindow : DragBase, IPointerEnterHandler, IPointerExitHandler
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
