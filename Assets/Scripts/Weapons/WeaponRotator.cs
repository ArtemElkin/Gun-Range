using UnityEngine;

public class WeaponRotator : MonoBehaviour, IRotatable
{
    [SerializeField] private Transform _pointOfRotationTransform;
    [SerializeField] private float _minRotationAngle;
    [SerializeField] private float _maxRotationAngle;
    private Vector2 _lastTargetPos;
    public void Rotate(Vector2 targetPos)
    {
        Vector2 currentPos = _pointOfRotationTransform.position;
        Vector2 direction = targetPos - currentPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, _minRotationAngle, _maxRotationAngle);

        _pointOfRotationTransform.rotation = Quaternion.Euler(0, 0, angle);
        _lastTargetPos = targetPos;
    }

    public Vector2 GetLastTargetPosition() => _lastTargetPos;
}