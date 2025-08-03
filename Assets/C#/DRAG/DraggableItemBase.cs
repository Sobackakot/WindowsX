using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class DraggableItemBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public ItemStateContext context { get; private set; }
    public Transform accepted_Transform { get; set; }
    public RectTransform rectTransform { get; set; }
    public Canvas canvas { get; private set; }
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

    }
    private void OnDisable()
    { 
        line.enabled = false;
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        context.SetIsDraggableItem(true);
        context.SetHasHitPointCursor(true);
        context.ResetBlocksRaycast(false, 0.5f, canvasGroup);
        accepted_Transform = transform.parent;
        rectTransform?.SetParent(canvas.transform);
        rectTransform?.SetAsLastSibling();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        context.SetHasHitPointCursor(true);
        context.SetIsDraggableItem(true);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(false);
        context.SetIsDraggableItem(false);

        context.ResetBlocksRaycast(true, 1, canvasGroup);
        rectTransform?.SetParent(accepted_Transform);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        context.LineEnable(line);// -----
        context.PointerEnter();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(false);// -----
        context.LineDisable(line);
        context.PointerExit();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        context.SetHasHitPointCursor(true);// -----
        context.LineEnable(line);
        context.PointerEnter();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
    }
}
