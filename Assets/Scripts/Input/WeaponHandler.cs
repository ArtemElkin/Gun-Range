using System;
using UnityEngine;

public class WeaponHandler
{
    [SerializeField] protected WeaponContainer _weaponContainer;
    private InputController _inputController;

    private void OnDisable()
    {
        _inputController.OnPointerHolding -= OnPointerHolding;
        _inputController.OnHoldingEnded -= OnHoldingEnded;
    }

    private void OnHoldingEnded(float timeHolded)
    {
        _weaponContainer.CurrentWeapon.Shoot(timeHolded);
    }

    public void Initialize(InputController input)
    {
        _inputController = input;
        _inputController.OnPointerHolding += OnPointerHolding;

    }
    private void OnPointerHolding(Vector2 pointerPos)
    {
        //_weaponContainer.CurrentWeapon.Rotate(pointerPos);
    }
}