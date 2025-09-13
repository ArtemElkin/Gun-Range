using UnityEngine;

[CreateAssetMenu(menuName = "Configs/WeaponConfig", fileName = "NewWeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [Header("Weapon Settings")]
    public Weapon weaponPrefab;
    
    [Header("Bullet Settings")]
    public Bullet bulletPrefab;
    
    [Header("Info")]
    public string weaponName;
    public Sprite icon;
}
