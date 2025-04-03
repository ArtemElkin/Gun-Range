using UnityEngine;
using UnityEngine.EventSystems;
public class TouchController : InputController
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = _mainCamera.ScreenToWorldPoint(touch.position);
                timeHolded = 0f;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                 // Проверка на нажатие на UI элемент
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                _weaponContainer.CurrentWeapon.Rotate(_mainCamera.ScreenToWorldPoint(touch.position));
                timeHolded += Time.deltaTime;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Проверка на нажатие на UI элемент
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                    
                _weaponContainer.CurrentWeapon.Shoot(timeHolded);
            }
        }
    }
}