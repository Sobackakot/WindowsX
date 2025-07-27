using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PointerEnterBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    { 
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
    }
}
