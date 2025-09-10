using System;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    [SerializeField] protected Camera _mainCamera;
    protected float timeHolded = 0f;
    public event Action<Vector2> OnPointerHolding;
    public event Action<float> OnHoldingEnded;
    protected void RaisePointerHolding(Vector2 position)
    {
        OnPointerHolding?.Invoke(position);
    }

    // Защищённый метод для вызова события HoldingEnded (если нужно)
    protected void RaiseHoldingEnded(float holdTime)
    {
        OnHoldingEnded?.Invoke(holdTime);
    }
}
