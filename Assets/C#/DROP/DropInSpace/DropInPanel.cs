using Drag.RegisterItem;
using UnityEngine;

[RequireComponent(typeof(HashDropContentOnPanel))]
public class DropInPanel : DropItemBase
{
    private void Awake()
    {
        reg = FindObjectOfType<RegistrySelectableItems>();
        rectTransform = GetComponent<RectTransform>();
        targetContent = rectTransform.GetComponent<HashDropContentOnPanel>()?.transform;
    }
}
