using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon, IRotatable
{
    [SerializeField] protected Transform _gunpoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _minRotationAngle;
    [SerializeField] private float _maxRotationAngle;
    protected WeaponType _weaponType;
    protected BulletSpawner _bulletSpawner;
    private Vector2 _lastTargetPos;
    
    public virtual void Initialize(WeaponType type, BulletSpawner spawner)
    {
        _bulletSpawner = spawner;
        _weaponType = type;
    }
    
    public void Rotate(Vector2 targetPos)
    {
        Vector2 currentPos = transform.position;
        Vector2 direction = targetPos - currentPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, _minRotationAngle, _maxRotationAngle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        _lastTargetPos = targetPos;
    }

    public abstract void Shoot(float timeHolded);

    public WeaponType GetWeaponType()
    {
        return _weaponType;
    }
    
    public Vector2 GetLastTargetPosition()
    {
        return _lastTargetPos;
    }

    // Здесь можно реализовать реакцию на выстрел - анимацию, звук и пр.
    protected void OnShoot(string animationTrigger = "Shoot")
    {
        _animator.SetTrigger(animationTrigger);
    }

    // Здесь можно реализовать различное поведение на появление оружия
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    // Здесь можно реализовать различное поведение на исчезновение оружия
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}