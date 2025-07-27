using UnityEngine;

public class HashWindowPanel : MonoBehaviour
{
    public RectTransform rectTransform { get; private set; }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
