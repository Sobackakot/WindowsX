using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivatorMenuWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject rightClickMenuPanel;  
    private RectTransform rectTrans;
    private void Awake()
    {
        if (rightClickMenuPanel != null)
        rectTrans = rightClickMenuPanel.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            NewPositionMenu(Input.mousePosition);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            NewPositionMenu(eventData.pressPosition);
        }
        else
        {
            rightClickMenuPanel?.SetActive(false);
        }
    }
    private void NewPositionMenu(Vector2 position)
    {
        rightClickMenuPanel?.SetActive(true);
        rectTrans.pivot = new Vector2(0f, 1f);
        rectTrans.anchorMin = new Vector2(0f, 1f);
        rectTrans.anchorMax = new Vector2(0f, 1f); 
        rectTrans.position = position; 
    }
}
