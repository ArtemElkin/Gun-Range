using UnityEngine;

public interface IRotatable
{
    void Rotate(Vector2 targetPos);
    Vector2 GetLastTargetPosition();
}
