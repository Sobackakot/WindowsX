using Drag.MultipleItem;
using Drag.RegisterItem;
using Drag.SingleItem;
using UnityEngine;
using UnityEngine.EventSystems;


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
        private bool isDraggingAll = false;

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

        public void OnPointerClick(PointerEventData eventData)
        { 
            if(!isDraggingAll)
                registry?.ResetItems();
            registry?.FindCurrentDraggableItem(); 
            registry?.currentDraggableItem?.OnPointerClick(eventData);
            isDraggingAll = false;
        }
         
      
    }
}