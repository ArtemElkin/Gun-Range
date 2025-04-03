using UnityEngine;

public class PhysicalBullet : Bullet
{
    [SerializeField] private float gravity = 9.8f;

    protected override void Move()
    {
        // Рассчитываем перемещение на основе текущей скорости
        Vector2 velocity = (Vector2)transform.position + new Vector2(
            CurrentDirection.x * CurrentSpeed * Time.fixedDeltaTime,
            CurrentDirection.y * CurrentSpeed * Time.fixedDeltaTime);
        
        // Применяем гравитацию
        ApplyGravity(velocity);
    }

    protected override void OnBoundaryExit()
    {
        base.OnBoundaryExit();
        gameObject.SetActive(false); // Деактивируем
    }

    private void ApplyGravity(Vector2 velocity)
    {
        float deltaTime = Time.time - TimeSpawned;
        float y = velocity.y - (gravity * Mathf.Pow(deltaTime, 2) / 2); // y = y - gt^2 / 2
        transform.position = new Vector2(velocity.x, y);
    }
}