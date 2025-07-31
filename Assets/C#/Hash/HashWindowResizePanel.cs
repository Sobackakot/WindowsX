using UnityEngine;

public class HashWindowResizePanel : MonoBehaviour
{
    public RectTransform rectTransform { get; private set; }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
