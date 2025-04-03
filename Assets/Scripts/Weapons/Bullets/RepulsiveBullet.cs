using UnityEngine;

public class RepulsiveBullet : Bullet, IBounceable
{
    private BounceHandler _bounceHandler;


    protected override void Awake()
    {
        base.Awake();
        _bounceHandler = new BounceHandler(Camera.main);
    }
    protected override void Move()
    {
        // Рассчитываем перемещение на основе текущей скорости
        transform.position += new Vector3(
            CurrentDirection.x * CurrentSpeed * Time.fixedDeltaTime,
            CurrentDirection.y * CurrentSpeed * Time.fixedDeltaTime,
            0);
    }

    protected override void OnBoundaryExit()
    {
        base.OnBoundaryExit();
        // Выбираем нормаль в зависимости от того, какой поверхности касается пуля
        Vector2 normal = _bounceHandler.DetermineBoundaryNormal(transform.position);
        Bounce(normal);
    }

    public void Bounce(Vector2 normal)
    {
        // Устанавливаем направление отскока
        CurrentDirection = _bounceHandler.Reflect(CurrentDirection, normal);
    }
}