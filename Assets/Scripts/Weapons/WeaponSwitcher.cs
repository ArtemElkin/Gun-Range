using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private WeaponContainer _container;
    [SerializeField] private SwitchWeaponTypeBtn _switchButton;
    private int _currentIndex = 0;

    public IWeapon CurrentWeapon => _container.CurrentWeapon;

    private void OnEnable()
    {
        _switchButton.OnSwitchWeaponRequested += SwitchWeapon;
    }

    private void OnDisable()
    {
        _switchButton.OnSwitchWeaponRequested -= SwitchWeapon;
    }

    private void Start()
    {
        if (_container.WeaponCount > 0)
        {
            _container.SetCurrentWeapon(0);
            _container.CurrentWeapon.Activate();
        }
    }

    private void SwitchWeapon()
    {
        if (_container.WeaponCount == 0) return;

        Vector2 lastTargetPos = Vector2.zero;

        if (_container.CurrentWeapon is Weapon oldWeapon)
        {
            if (oldWeapon.Rotator != null)
            {
                lastTargetPos = oldWeapon.Rotator.GetLastTargetPosition();
            }
            oldWeapon.Deactivate();
        }

        _currentIndex = (_currentIndex + 1) % _container.WeaponCount;
        _container.SetCurrentWeapon(_currentIndex);
        _container.CurrentWeapon.Activate();

        if (_container.CurrentWeapon is Weapon newWeapon && newWeapon.Rotator != null)
        {
            newWeapon.Rotator.Rotate(lastTargetPos);
        }
    }
}