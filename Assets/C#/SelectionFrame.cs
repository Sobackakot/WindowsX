using Drag.Item;
using Drag.RegisterItem;
using System;
using UnityEngine;

namespace Drag.SelectItem
{
    public class SelectionFrame : MonoBehaviour
    { 
        public event Action<DragBase> OnAddSelectedItem; 
        public event Func<bool> OnPointerEnter;
        public event Action OnResetSelectedItems;


        RegistrySelectableItems registry;
        public GUISkin GUISkin; // GUI skin for the selection box.
        private Rect screenSpaceRect; // Rectangle representing the selection box. 

        private Vector2 startPoint; // Starting point of the selection box.
        private Vector2 endPoint; // Ending point of the selection box.
        private int sortingLayer = 99; // Sorting layer for the GUI.
        private float minDragDistance = 10f; // Minimum distance to start drawing the frame. 
        public bool onSelectionStay { get; private set; }


        private void OnEnable()
        {
            OnResetSelectedItems?.Invoke();
        }
        private void Awake()
        {
            registry = GetComponent<RegistrySelectableItems>();
        }

        private void OnGUI()
        { 
            GUI.skin = GUISkin;
            GUI.depth = sortingLayer;
            SelectionStart();
            SelectionStay();

        }
        public void Update()
        { 
            SelectionEnd();
        }
        private void SelectionStart()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = Input.mousePosition; 
                if (OnPointerEnter.Invoke()) return; 
                onSelectionStay = true;
                OnResetSelectedItems?.Invoke(); 
            }
        }
        private void SelectionStay()
        {
            if (Input.GetMouseButton(0) && onSelectionStay)
            { 
                endPoint = Input.mousePosition;
                if (Vector2.Distance(startPoint, endPoint) < minDragDistance) return;   
                screenSpaceRect = GetRectFrame(startPoint, endPoint);
                DrawFrame(screenSpaceRect); 
            }
        }

        private void SelectionEnd()
        {
            if (Input.GetMouseButtonUp(0))
            {
                endPoint = Input.mousePosition; 
                SelectionFrameFromScreen(screenSpaceRect);
                onSelectionStay = false; 
            }
        }
        //��������� ���������� �������������
        private Rect GetRectFrame(Vector2 startPoint, Vector2 endPoint)
        {
            float posX = Mathf.Min(startPoint.x, endPoint.x);
            float posY = Mathf.Min(startPoint.y, endPoint.y);
            float widthX = Mathf.Abs(endPoint.x - startPoint.x);
            float heightY = Mathf.Abs(endPoint.y - startPoint.y);

            return new Rect(posX, posY, widthX, heightY);
        }

        //������������ GUI.Box � ������������� ����� ������.
        private void DrawFrame(Rect screenRect)
        {
            //Unity GUI ���������� �������� ���������� ����� �����, � � Screen Space Y ��� ����
            //������� y ���������� ��������������: Screen.height - y - height.

            float x = screenRect.x;
            float y = Screen.height - screenRect.y - screenRect.height;
            float width = screenRect.width;
            float height = screenRect.height;

            Rect newBox = new Rect(x, y, width, height);
            GUI.Box(newBox, "");
        }

        private void SelectionFrameFromScreen(Rect screen)
        {
            foreach (var item in registry.draggableItems)
            {
                Rect itemRect = GetRectItem(item);
                //���������, ������������ �� ��������������
                if (screen.Overlaps(itemRect, true) && item.gameObject.layer == 7)
                {
                    item?.context.SetInSelectionFrame(item.line);
                    item?.context.LineEnable(item.line);
                    OnAddSelectedItem?.Invoke(item);
                    screenSpaceRect = Rect.zero;
                }
            }
        }

        //��������� ������������� (DraggableItem item) - UI-������� �� ������
        private Rect GetRectItem(DragBase item)
        {
            Vector3[] positions = new Vector3[4];
            item?.rectTransform.GetWorldCorners(positions);//���������� 4 ���� RectTransform � ������� �����������.

            //�� �������� ���������� � �������� ������������.
            Vector2 startPoint = RectTransformUtility.WorldToScreenPoint(null, positions[0]);
            Vector2 endPoint = RectTransformUtility.WorldToScreenPoint(null, positions[2]);

            float x = Mathf.Min(startPoint.x, endPoint.x);
            float y = Mathf.Min(startPoint.y, endPoint.y);
            float width = Mathf.Abs(endPoint.x - startPoint.x);
            float height = Mathf.Abs(endPoint.y - startPoint.y);

            return new Rect(x, y, width, height);
        } 
    }
}

 