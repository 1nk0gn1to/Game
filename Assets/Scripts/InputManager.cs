using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interaction.performed += Interaction_performed;
    }

    private void Interaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        var direction = playerInputActions.Player.Move.ReadValue<Vector2>();

        direction = direction.normalized;

        return direction;
    }
}
