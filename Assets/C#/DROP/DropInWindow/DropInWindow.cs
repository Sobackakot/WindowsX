using Drag.RegisterItem;
using UnityEngine;

public class DropInWindow : DropItemBase
{
    private void Awake()//----
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponentInChildren<HashDropContentOnWindow>()?.transform;
    }
}
