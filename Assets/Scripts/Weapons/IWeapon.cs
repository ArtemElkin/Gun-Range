using UnityEngine;

public interface IWeapon
{
    void Shoot(float timeHolded);   // Сделать выстрел
    WeaponType GetWeaponType(); // Возвращает тип оружия
    void Activate();    // Здесь можно реализовать различное поведение на появление оружия
    void Deactivate();  // Здесь можно реализовать различное поведение на исчезновение оружия
}