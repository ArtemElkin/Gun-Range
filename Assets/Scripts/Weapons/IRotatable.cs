using UnityEngine;

public interface IRotatable
{
    void Rotate(Vector2 targetPos); // Поворачивает оружие в заданную сторону
    Vector2 GetLastTargetPosition();    // Возвращает последнюю точку, куда смотрело оружие
}