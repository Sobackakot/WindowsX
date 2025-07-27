using UnityEngine;
using UnityEngine.EventSystems;

namespace Drag.Resize
{
    public class ResizePanel : MonoBehaviour, IDragHandler
    {
        public float minWidth = 100;
        public float minHeight = 100;

        public float maxWidth = 1920;
        public float maxHeight = 1080;
        public enum ResizeDirection { Left, Right, Top, Bottom }
        public ResizeDirection direction;

        private RectTransform target; 
        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            target = GetComponentInParent<HashWindowPanel>().rectTransform;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 delta = eventData.delta / canvas.scaleFactor;

            switch (direction)
            {
                case ResizeDirection.Left:
                    ResizeLeft(delta.x);
                    break;
                case ResizeDirection.Right:
                    ResizeRight(delta.x);
                    break;
                case ResizeDirection.Top:
                    ResizeTop(delta.y);
                    break;
                case ResizeDirection.Bottom:
                    ResizeBottom(delta.y);
                    break;
            }
        }

        void ResizeLeft(float dx)
        { 
            float normalizeDx = dx / target.lossyScale.x;
            float newWidth = target.rect.width - normalizeDx;
            if(minWidth <= newWidth)
                target.offsetMin += new Vector2(normalizeDx, 0);
        }

        void ResizeRight(float dx)
        { 
            float normalizedDx = dx/ target.lossyScale.x;
            float newWidth = target.rect.width + normalizedDx;
            if(minWidth <= newWidth)
                target.offsetMax += new Vector2(normalizedDx, 0);
        }

        void ResizeTop(float dy)
        { 
            float normalizedDy = dy / target.lossyScale.y;
            float newHeight = target.rect.height + normalizedDy;
            if(minHeight <=newHeight)
                target.offsetMax += new Vector2(0, normalizedDy);
        }

        void ResizeBottom(float dy)
        {
            float normalizeDy = dy / target.lossyScale.y;
            float newHeight = target.rect.height - normalizeDy;
            if(minHeight <=newHeight)
             target.offsetMin += new Vector2(0, normalizeDy);
        }
    }
}

