using UnityEngine;

public class CursorCastom : MonoBehaviour
{
    public Texture2D defaultCursor; // ������ �� ���������
    public Texture2D clickCursor;   // ������ ��� �����


    // "������� �����" (Hotspot) � �����, ��� ���������� ����.
    // Vector2.zero (0,0) � ��� ����� ������� ����.
    // ���� ��� ������, ��������, �����������, ���������� ��� � �����.
    public Vector2 hotSpot = Vector2.zero;

    // ����� �������: Auto (����������) ��� ForceSoftware (�����������).
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // �������� ����� ��� ��������� ������ �������
        SetCustomCursor();
    }

    private void SetCustomCursor()
    {
        // �����, ������� ������ ��������� ������.
        // ���������: ��������, ������� �����, ����� ����������.
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }
    void Update()
    {
        // ���������, ������ �� ����� ������ ���� (������ 0)
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ��, ������ ������ �� "����"
            Cursor.SetCursor(clickCursor, hotSpot, cursorMode);
        }

        // ���������, �������� �� ����� ������ ����
        if (Input.GetMouseButtonUp(0))
        {
            // ���� ��, ���������� ������ �� ���������
            Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
        }
    }
}
