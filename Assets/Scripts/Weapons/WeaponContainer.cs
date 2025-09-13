using System.Collections.Generic;
using UnityEngine;


public class WeaponContainer : MonoBehaviour
{
    public int WeaponCount => _weapons.Count;
    public IWeapon CurrentWeapon => _currentWeapon;
    private List<IWeapon> _weapons;
    private IWeapon _currentWeapon;


    private void Awake()
    {
        if (_weapons == null)
        {
            _weapons = new List<IWeapon>();
        }
    }
    public IWeapon GetWeapon(int index) => index >= 0 && index < _weapons.Count ? _weapons[index] : null;
    public void SetCurrentWeapon(int index)
    {
        if (index >= 0 && index < _weapons.Count)
        {
            _currentWeapon = _weapons[index];
        }
    }
    public void Add(IWeapon weapon)
    {
        _weapons.Add(weapon);
        if (CurrentWeapon == null)
        {
            _currentWeapon = weapon;
        }
    }
}