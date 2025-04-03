using UnityEngine;

public interface IWeapon
{
    void Rotate(Vector2 targetPos); // Поворачивает оружие в заданную сторону
    void Shoot(float timeHolded);   // Сделать выстрел
    WeaponType GetWeaponType(); // Возвращает тип оружия
    void Activate();    // Здесь можно реализовать различное поведение на появление оружия
    void Deactivate();  // Здесь можно реализовать различное поведение на исчезновение оружия
    Vector2 GetLastTargetPosition();    // Возвращает последнюю точку, куда смотрело оружие
}