using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] protected WeaponContainer _weaponContainer;
    [SerializeField] protected Camera _mainCamera;
    protected Vector2 startTouchPos;
    protected float timeHolded = 0f;
}
