using Drag.RegisterItem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class DraggableItemBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public ItemStateContext context { get; private set; }
    public Transform accepted_Transform { get; set; }
    public RectTransform rectTransform { get; set; }
    private Canvas canvas;
    public Outline line { get; private set; }
    public CanvasGroup canvasGroup { get; private set; }


    private void Awake()
    { 
        context = new ItemStateContext();
        accepted_Transform = GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();
        canvas = accepted_Transform.GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        line = GetComponent<Outline>();
    }
    private void OnEnable()
    {
        line.enabled = false;
        context.SetHasHitPointCursor(false);
        context.SetIsActive(true);

    }
    private void OnDisable()
    {
        context.SetIsActive(false);

        line.enabled = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        context.SetIsDraggableItem(true);
        context.SetHasHitPointCursor(true);
        context.ResetBlocksRaycast(false, 0.5f, canvasGroup);
        accepted_Transform = transform.parent;
        rectTransform?.SetParent(canvas.transform);
        rectTransform?.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        context.SetHasHitPointCursor(true);
        context.SetIsDraggableItem(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        context.SetHasHitPointCursor(false);
        context.SetIsDraggableItem(false);

        context.ResetBlocksRaycast(true, 1, canvasGroup);
        rectTransform?.SetParent(accepted_Transform);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    { 
        context.LineEnable(line);
        context.PointerEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(false);
        context.LineDisable(line);
        context.PointerExit();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(true);
        context.LineEnable(line); 
        context.PointerEnter();
    }
}
