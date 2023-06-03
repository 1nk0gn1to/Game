using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVector()
    {
        var direction = playerInputActions.Player.Move.ReadValue<Vector2>();

        direction = direction.normalized;

        return direction;
    }
}
