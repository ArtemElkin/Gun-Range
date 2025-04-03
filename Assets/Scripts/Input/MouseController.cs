using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : InputController
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            timeHolded = 0f;
        }
        else if (Input.GetMouseButton(0))
        {
             // Проверка на нажатие на UI элемент
            if (EventSystem.current.IsPointerOverGameObject())
                    return;
                    
            _weaponContainer.CurrentWeapon.Rotate(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
            timeHolded += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Проверка на нажатие на UI элемент
            if (EventSystem.current.IsPointerOverGameObject())
                    return;
                    
            _weaponContainer.CurrentWeapon.Shoot(timeHolded);
        }
    }
}