using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _directionDotProductThreshold;

    private PlayerMovement _movement;
    private PlayerControls _inputActions;

    #region MonoBehaviour

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Dodging.performed += OnDodgingPerform;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Dodging.performed -= OnDodgingPerform;
    }

    #endregion

    private void OnDodgingPerform(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var delta = _inputActions.Player.DodgingDirection.ReadValue<Vector2>();
        if (Vector2.Dot(delta, Vector2.up) > _directionDotProductThreshold)
        {
            _movement.TryDodgeUp();
        }
        else if (Vector2.Dot(delta, Vector2.down) > _directionDotProductThreshold)
        {
            _movement.TryDodgeDown();
        }
    }
}
