using UnityEngine;


// Здесь можно было бы реализовать object пул для спавна нескольких пуль
public class BulletSpawner
{
    private Bullet _currentBullet;
    

    public BulletSpawner(Bullet bullet)
    {
        _currentBullet = bullet;
    }

    public void SpawnBullet(Vector3 startPosition, Vector2 startDirection, float speed)
    {
        if (_currentBullet != null)
        {
            _currentBullet.transform.position = startPosition;
            _currentBullet.Initialize(startDirection, speed);
        }
    }
}