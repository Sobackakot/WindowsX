using Drag.RegisterItem;
using UnityEngine;

public class DropItemInWindow : DropBase
{ 
    private void Awake()
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponentInChildren<HashContent>()?.transform; 
    } 
} 