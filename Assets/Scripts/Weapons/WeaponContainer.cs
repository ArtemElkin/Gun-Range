using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    REPULSIVE,  // Стреляет отталкивающими снарядами
    PHYSICAL    // Стреляет физическими снарядами
}

public class WeaponContainer : MonoBehaviour
{
    public IWeapon CurrentWeapon => _currentWeapon;
    [SerializeField] private RepulsiveWeapon _repulsiveWeapon;
    [SerializeField] private PhysicalWeapon _physicalWeapon;
    [SerializeField] private RepulsiveBullet _repulsiveBullet;
    [SerializeField] private PhysicalBullet  _physicalBullet;
    private IWeapon _currentWeapon;

    private Dictionary<WeaponType, IWeapon> _currentWeaponDict;

    private void Awake()
    {
        // Создаём словарь типов оружия с парами <Тип : Оружие>
        _currentWeaponDict = new Dictionary<WeaponType, IWeapon>();

        // Создаём оба типа оружия 

        BulletSpawner repulsiveBulleSpawner = new BulletSpawner(_repulsiveBullet);
        _repulsiveWeapon.Initialize(WeaponType.REPULSIVE, repulsiveBulleSpawner);
        _currentWeaponDict.Add(WeaponType.REPULSIVE, _repulsiveWeapon);

        BulletSpawner physicalBulletSpawner = new BulletSpawner(_physicalBullet);
        _physicalWeapon.Initialize(WeaponType.PHYSICAL, physicalBulletSpawner);
        _currentWeaponDict.Add(WeaponType.PHYSICAL, _physicalWeapon);

        // Устанавливаем начальное оружие
        SelectWeaponType(WeaponType.REPULSIVE);
    }

    // Переключение между двумя типами оружий
    public void SwitchWeaponType()
    {
        
        if (_currentWeapon.GetWeaponType() == WeaponType.REPULSIVE)
            SelectWeaponType(WeaponType.PHYSICAL);
        else
            SelectWeaponType(WeaponType.REPULSIVE);
    }

    // Выбор любого типа оружия
    public void SelectWeaponType(WeaponType type)
    {
        Vector2 lastTargetPos = Vector2.zero;
        if (_currentWeapon != null)
        {
            _currentWeapon.Deactivate();
            // Сохраняем точку, куда было направлено предыдущее оружие
            lastTargetPos = _currentWeapon.GetLastTargetPosition();
        }
        _currentWeapon = _currentWeaponDict[type];
        _currentWeapon.Activate();

        // Поворот нового оружия в ту же сторону, что и предыдущее
        _currentWeapon.Rotate(lastTargetPos);
    }
}