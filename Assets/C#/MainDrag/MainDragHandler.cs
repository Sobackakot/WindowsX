using UnityEngine;
using UnityEngine.EventSystems;
using Drag.RegisterItem;
using Drag.SingleItem;
using Drag.MultipleItem;
using Drag.Resize;


namespace Drag.Item.Maim
{
    public class MainDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private RegistrySelectableItems registry; 

        private MultipleBeginDrag multipleBeginDrag;
        private MultipleDrag multipleDrag;
        private MultipleEndDrag multipleEndDrag;

        private SingleBeginDrag singleBeginDrag;
        private SingleDrag singleDrag;
        private SingleEndDrag singleEndDrag; 
        private bool isDragging = false;

        private void Awake()
        {
            registry = GetComponent<RegistrySelectableItems>();

            multipleBeginDrag = GetComponent<MultipleBeginDrag>();
            multipleDrag = GetComponent<MultipleDrag>();
            multipleEndDrag = GetComponent<MultipleEndDrag>();

            singleBeginDrag = GetComponent<SingleBeginDrag>();
            singleDrag = GetComponent<SingleDrag>();
            singleEndDrag = GetComponent<SingleEndDrag>(); 

        } 

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("begin drag");
            registry?.SetCurrentDraggableItem();
            singleBeginDrag?.OnSingleBeginDrag(eventData, registry.currentDraggableItem); 
            isDragging = multipleBeginDrag.OnMultipleBeginDrag(eventData, registry.currentDraggableItem); 
        }

        public void OnDrag(PointerEventData eventData)
        { 
            if (!isDragging)
                singleDrag?.OnSingleDrag(eventData, registry.currentDraggableItem);
            multipleDrag?.OnMultipleDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            multipleEndDrag?.OnMultipleEndDrag(eventData);
            singleEndDrag?.OnSingleEndDrag(eventData, registry.currentDraggableItem);
            isDragging = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            registry?.ResetItems();
            registry?.SetCurrentDraggableItem(); 
            registry?.currentDraggableItem?.OnPointerClick(eventData);
            Debug.Log("click");
        }
         
      
    }
}