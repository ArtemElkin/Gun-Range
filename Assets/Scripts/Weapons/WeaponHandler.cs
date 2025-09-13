using System;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] protected WeaponContainer _weaponContainer;
    private InputController _inputController;
    private void Awake()
    {
        _inputController = FindFirstObjectByType<InputController>();
        if (_inputController == null)
        {
            Debug.LogError("InputController not found in the scene.");
        }
        if (_weaponContainer == null)
        {
            Debug.LogError("WeaponContainer is not assigned in the inspector.");
        }
    }
    private void OnEnable()
    {
        _inputController.OnPointerHolding += OnPointerHolding;
        _inputController.OnHoldingEnded += OnHoldingEnded;
    }
    private void OnDisable()
    {
        _inputController.OnPointerHolding -= OnPointerHolding;
        _inputController.OnHoldingEnded -= OnHoldingEnded;
    }

    private void OnHoldingEnded(float timeHolded)
    {
        _weaponContainer.CurrentWeapon.Shoot(timeHolded);
    }

    private void OnPointerHolding(Vector2 pointerPos)
    {
        if (_weaponContainer.CurrentWeapon is Weapon weapon && weapon.Rotator != null)
        {
            weapon.Rotator.Rotate(pointerPos);
        }
    }
}