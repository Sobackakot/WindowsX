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
        context.SetIsActive(true);

    }
    private void OnDisable()
    {
        context.SetIsActive(false); 
        line.enabled = false;
    }
    public abstract void OnBeginDrag(PointerEventData eventData);

    public abstract void OnDrag(PointerEventData eventData);

    public abstract void OnEndDrag(PointerEventData eventData);

    public abstract void OnPointerEnter(PointerEventData eventData);

    public abstract void OnPointerExit(PointerEventData eventData);

    public abstract void OnPointerClick(PointerEventData eventData);

    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract void OnPointerUp(PointerEventData eventData);
}
