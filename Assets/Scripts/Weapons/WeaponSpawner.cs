using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private WeaponContainer _weaponContainer;
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private WeaponConfig[] _weaponConfigs;

    private void Start()
    {
        SpawnAllWeapons();
    }

    private void SpawnAllWeapons()
    {
        foreach (var config in _weaponConfigs)
        {
            SpawnWeapon(config);
        }
    }

    private void SpawnWeapon(WeaponConfig config)
    {
        if (config.weaponPrefab == null || config.bulletPrefab == null)
        {
            Debug.LogWarning($"WeaponConfig {config.name} is missing prefab(s)!");
            return;
        }

        // Спавним оружие
        Weapon weaponInstance = Instantiate(config.weaponPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);

        // Создаём BulletSpawner с привязкой к bulletPrefab
        Bullet bulletInstance = Instantiate(config.bulletPrefab);
        bulletInstance.gameObject.SetActive(false); // выключаем пулю, пока не нужна
        BulletSpawner bulletSpawner = new BulletSpawner(bulletInstance);

        // Инициализируем оружие
        weaponInstance.Initialize(bulletSpawner);

        // Добавляем в контейнер
        _weaponContainer.Add(weaponInstance);
        weaponInstance.Deactivate();
    }
}
