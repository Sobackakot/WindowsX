using UnityEngine;

public class CursorCastom : MonoBehaviour
{
    public Texture2D defaultCursor; // Курсор по умолчанию
    public Texture2D clickCursor;   // Курсор для клика


    // "Горячая точка" (Hotspot) — точка, где происходит клик.
    // Vector2.zero (0,0) — это левый верхний угол.
    // Если ваш курсор, например, перекрестие, установите его в центр.
    public Vector2 hotSpot = Vector2.zero;

    // Режим курсора: Auto (аппаратный) или ForceSoftware (программный).
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // Вызываем метод для установки нового курсора
        SetCustomCursor();
    }

    private void SetCustomCursor()
    {
        // Метод, который меняет системный курсор.
        // Параметры: текстура, горячая точка, режим рендеринга.
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }
    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши (кнопка 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Если да, меняем курсор на "клик"
            Cursor.SetCursor(clickCursor, hotSpot, cursorMode);
        }

        // Проверяем, отпущена ли левая кнопка мыши
        if (Input.GetMouseButtonUp(0))
        {
            // Если да, возвращаем курсор по умолчанию
            Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
        }
    }
}
