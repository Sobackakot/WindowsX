using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



namespace Drag.SelectItem
{
    public class PointerEnterAction : MonoBehaviour
    {
        private SelectionFrame select;
        private void Awake()
        {
            select = GetComponent<SelectionFrame>();
        }
        private void OnEnable()
        {
            select.OnPointerEnter += IsPointerOverAnyDraggable;
        }
        private void OnDisable()
        {
            select.OnPointerEnter -= IsPointerOverAnyDraggable;
        }
        public bool IsPointerOverAnyDraggable()
        {
            foreach (var hit in GetRaycastHitResults())
                if (hit.gameObject.GetComponent<HashPointerEnter>()) return true;
            return false;
        }
        private List<RaycastResult> GetRaycastHitResults()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> hitResults = new();
            EventSystem.current.RaycastAll(pointerData, hitResults);
            return hitResults;
        }
    }
}