using UnityEngine;

public class SlotWindow : MonoBehaviour
{
   public Transform trSlot { get; set; }
   public RectTransform rectTrSlot { get; set; }
    private void Awake()
    {
        trSlot = GetComponent<Transform>();
        rectTrSlot = GetComponent<RectTransform>();
    }
}
