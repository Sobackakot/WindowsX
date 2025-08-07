using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMouseHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject rightClickMenuPanel; 
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClickMenuPanel?.SetActive(true);
            rightClickMenuPanel.transform.position = eventData.pressPosition;
        }
        else
        {
            rightClickMenuPanel?.SetActive(false);
        }
    }
}
