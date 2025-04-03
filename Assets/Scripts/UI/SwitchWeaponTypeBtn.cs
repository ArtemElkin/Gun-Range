using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class SwitchWeaponTypeBtn : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WeaponContainer _weaponContainer;
    
    private void OnEnable()
    {
        _btn.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _btn.onClick?.RemoveListener(OnClick);
    }

    private void UpdateText()
    {
        if (_weaponContainer.CurrentWeapon.GetWeaponType() == WeaponType.REPULSIVE)
            _text.text = "Переключить на тип 2";
        else if (_weaponContainer.CurrentWeapon.GetWeaponType() == WeaponType.PHYSICAL)
            _text.text = "Переключить на тип 1";
        else
            _text.text = "Переключить";
    }

    private void OnClick()
    {
        _weaponContainer.SwitchWeaponType();
        UpdateText();
    }
}