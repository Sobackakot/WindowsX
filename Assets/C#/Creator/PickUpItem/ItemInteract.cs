using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteract : MonoBehaviour, IPointerClickHandler
{
    private Transform transParent;
    [SerializeField] private GameObject prefab;

    private float lastClickTime = 0f; //seconds to check the elapsed time between clicks
    private float doubleClickThreshold = 0.3f; //time between double clicks


    private GameObject window;
    private void Start()
    {
        transParent = GetComponentInParent<HashMainCanvas>()?.transform;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            HandleLeftMouseButtonClick();
        }
        else
        {
            RightMouseButtonClick();
        }
        
    }
    private void HandleLeftMouseButtonClick()  
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if (timeSinceLastClick <= doubleClickThreshold)
        {
            if (window == null && transParent != null && prefab != null)
            {
                window = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                window.transform.SetParent(transParent);
                RectTransform transRect = window.GetComponent<RectTransform>();

                transRect.pivot = new Vector2(0f, 1f);
                transRect.anchorMin = new Vector2(0f, 1f);
                transRect.anchorMax = new Vector2(0f, 1f);
                transRect.anchoredPosition = new Vector3(700, -200, 0);
                if (window != null) window.SetActive(true);
            } 
        }
        lastClickTime = Time.time;
    }
    public void RightMouseButtonClick()
    {

    }
}
