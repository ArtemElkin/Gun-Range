using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public IRotatable Rotator => _rotator;
    [SerializeField] protected Transform _gunpoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private WeaponRotator _rotator;
    protected BulletSpawner _bulletSpawner;
    
    public virtual void Initialize(BulletSpawner spawner)
    {
        _bulletSpawner = spawner;
    }

    public abstract void Shoot(float timeHolded);

    protected void OnShoot(string animationTrigger = "Shoot")
    {
        _animator.SetTrigger(animationTrigger);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}