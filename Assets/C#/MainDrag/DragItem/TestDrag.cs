using Drag.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Outline))]
public class TestDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    DraggableItem draggItem;

    public Transform accepted_Transform { get; set; }
    public RectTransform rectTransform { get; set; }
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Outline line;
    public bool hasHitPointCursor { get; private set; }
    public bool isDraggableItem { get; private set; }
    public bool inSelectionFrame { get; private set; }

    public bool isActiv { get; private set; }
    private void OnEnable()
    {
        draggItem = GetComponent<DraggableItem>(); 
        isActiv = true;
    }
    private void OnDisable()
    {
        if (draggItem == null) return;
        draggItem.enabled = true;
        isActiv = false;
    }
    private void Awake()
    {
        accepted_Transform = GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();
        canvas = accepted_Transform.GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        line = GetComponent<Outline>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraggableItem = true;
        hasHitPointCursor = true;
        ResetBlocksRaycast(false, 0.5f);
        accepted_Transform = transform.parent;
        rectTransform?.SetParent(canvas.transform);
        rectTransform?.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        hasHitPointCursor = true;
        isDraggableItem = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraggableItem = false;
        hasHitPointCursor = false;
        ResetBlocksRaycast(true, 1);
        rectTransform?.SetParent(accepted_Transform);
    }
    public void ResetBlocksRaycast(bool isBlock, float value)
    {
        canvasGroup.blocksRaycasts = isBlock;
        canvasGroup.alpha = value;
    }
}
