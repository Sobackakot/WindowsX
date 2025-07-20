using UnityEngine;

public class HashWIndow : MonoBehaviour
{
    public RectTransform rectTransform { get; set; }
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
