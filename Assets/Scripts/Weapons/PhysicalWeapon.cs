using UnityEngine;

public class PhysicalWeapon : Weapon
{
    private const float SpeedMultiplier = 5f;


    public override void Shoot(float timeHolded)
    {
        // Задаём направление вдоль дула оружия
        Vector2 newDir = _gunpoint.right;

        // Рассчитываем скорость в зависимости от длительности нажатия
        float speed = CalculateSpeed(timeHolded);   
        
        // Спавним пулю
        _bulletSpawner.SpawnBullet( _gunpoint.position, newDir, speed);
        
        OnShoot();
    }

    private float CalculateSpeed(float timeHolded)
    {
        return timeHolded * SpeedMultiplier;
    }
}