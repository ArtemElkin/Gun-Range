using UnityEngine;

public class BounceHandler
{
    private readonly Camera _mainCamera;

    public BounceHandler(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }

    public Vector2 DetermineBoundaryNormal(Vector2 position)
    {
        // Определяем позицию в координатах Viewport
        Vector2 viewportPos = _mainCamera.WorldToViewportPoint(position);
        if (viewportPos.x > 1f) return Vector2.left;  // Правая граница
        if (viewportPos.x < 0f) return Vector2.right; // Левая граница
        if (viewportPos.y > 1f) return Vector2.down;  // Верхняя граница
        if (viewportPos.y < 0f) return Vector2.up;    // Нижняя граница
        return Vector2.down; // По умолчанию
    }

    public Vector2 Reflect(Vector2 direction, Vector2 normal)
    {
        // Получаем скалярное произведение между текущим направлением и нормалью
        float dot = Vector2.Dot(direction, normal);
        // Вычисляем отражённый вектор
        return direction - 2 * dot * normal;
    }
}