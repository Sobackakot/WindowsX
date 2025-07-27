using Drag.RegisterItem;
using UnityEngine;

public class DropInWindow : DropBase
{ 
    private void Awake()
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponentInChildren<HashContent>()?.transform; 
    } 
} 