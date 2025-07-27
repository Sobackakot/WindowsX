using UnityEngine.EventSystems;

namespace Drag.Item
{
    public class DraggableItem : DragBase, IPointerEnterHandler, IPointerExitHandler
    {
        TestDrag drag;
        private void OnEnable()
        {
            drag = GetComponent<TestDrag>();
            context.SetIsActive(true);
        }
        private void OnDisable()
        {
            context.SetIsActive(false);
            if (drag == null) return;
            drag.enabled = true;
        }
    }
}

