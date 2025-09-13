using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class SwitchWeaponTypeBtn : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private WeaponContainer _weaponContainer;
    public event Action OnSwitchWeaponRequested;
    private void OnEnable()
    {
        _btn.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _btn.onClick?.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        OnSwitchWeaponRequested?.Invoke();
    }
}