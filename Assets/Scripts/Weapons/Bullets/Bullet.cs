using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private bool _isActive;
    private float _currentSpeed;
    private Vector2 _currentDirection;
    private float _timeSpawned;
    private Camera _mainCamera;

    protected Vector2 CurrentDirection
    {
        get => _currentDirection;
        set => _currentDirection = value;
    }
    protected bool IsActive => _isActive;
    protected float CurrentSpeed => _currentSpeed;
    protected float TimeSpawned => _timeSpawned;

    protected virtual void Awake()
    {
        _mainCamera = Camera.main;
    }

    protected void FixedUpdate()
    {
        CheckScreenBoundaries();
        if (IsActive)
        {
            Move();
        }
    }

    public void Initialize(Vector2 direction, float speed)
    {
        _currentDirection = direction;
        _currentSpeed = speed;
        _isActive = true;
        _timeSpawned = Time.time;
        gameObject.SetActive(true); // Активируем пулю
    }

    private void CheckScreenBoundaries()
    {
        Vector2 viewPortPos = _mainCamera.WorldToViewportPoint(transform.position);
        if (viewPortPos.x > 1 || viewPortPos.x < 0 || viewPortPos.y > 1 || viewPortPos.y < 0)
        {
            OnBoundaryExit();
        }
    }

    protected abstract void Move();
    protected virtual void OnBoundaryExit() { }
}