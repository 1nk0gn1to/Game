using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector3 GetMovementVector()
    {
        var direction = playerInputActions.Player.Move.ReadValue<Vector3>();

        direction = direction.normalized;

        return direction;
    }
}
