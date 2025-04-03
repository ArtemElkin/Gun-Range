using UnityEngine;

public class RepulsiveWeapon : Weapon
{
    private const float RepulsiveSpeed = 5f;


    public override void Shoot(float timeHolded)
    {
        // Задаём направление вдоль дула оружия
        Vector2 newDir = _gunpoint.right;

        // Спавним пулю
        _bulletSpawner.SpawnBullet(_gunpoint.position, newDir, RepulsiveSpeed);
        
        OnShoot();
    }
}