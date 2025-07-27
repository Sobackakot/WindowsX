using Drag.RegisterItem;
using UnityEngine;

public class DropInSpace : DropBase
{
    private void Awake()
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponent<Canvas>()?.transform;
    }
}
