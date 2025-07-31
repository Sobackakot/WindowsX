using Drag.MultipleItem;
using Drag.RegisterItem;
using Drag.SingleItem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Drag.Item.Maim
{
    public class MainDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        private RegistrySelectableItems registry; 

        private MultipleBeginDrag multipleBeginDrag;
        private MultipleDrag multipleDrag;
        private MultipleEndDrag multipleEndDrag;

        private SingleBeginDrag singleBeginDrag;
        private SingleDrag singleDrag;
        private SingleEndDrag singleEndDrag; 
        private bool isDraggingAll = false;

        private ScrollRect scrollRect;

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
            registry?.FindCurrentDraggableItem();
            singleBeginDrag?.OnSingleBeginDrag(eventData, registry.currentDraggableItem); 
            isDraggingAll = multipleBeginDrag.OnMultipleBeginDrag(eventData, registry.currentDraggableItem); 
        }

        public void OnDrag(PointerEventData eventData)
        { 
            if (!isDraggingAll)
                singleDrag?.OnSingleDrag(eventData, registry.currentDraggableItem);
            multipleDrag?.OnMultipleDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            multipleEndDrag?.OnMultipleEndDrag(eventData);
            singleEndDrag?.OnSingleEndDrag(eventData, registry.currentDraggableItem); 
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            registry?.FindCurrentDraggableItem();
            registry?.currentDraggableItem?.OnPointerDown(eventData);
            scrollRect = registry?.currentDraggableItem?.GetComponentInParent<ScrollRect>();
            if(scrollRect!=null)
            scrollRect.enabled = false;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            registry?.currentDraggableItem?.OnPointerUp(eventData);
            if (scrollRect != null)
                scrollRect.enabled = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isDraggingAll)
                registry?.ResetItems();  
            registry?.currentDraggableItem?.OnPointerClick(eventData);
            isDraggingAll = false;
        }   
    }
}