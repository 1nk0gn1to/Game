using Entities;
using System;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float ROTATE_SPEED = 10f;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private InputManager inputManager = default;
    [SerializeField] private LayerMask counterLayerMask = default;
    private bool isWalking;
    private Vector3 lastInteractDirection;

    public Action Select { get; set; }

    void Start()
    {
        inputManager.OnInteractAction += InputManager_OnInteractionAction;
    }

    private void InputManager_OnInteractionAction(object sender, EventArgs e)
    {
        Vector2 vector = inputManager.GetMovementVector(); 

        Vector3 moveDir = new Vector3(vector.x, 0f, vector.y);

        float maxDistance = 2f;

        if (moveDir != Vector3.zero)
        {
            lastInteractDirection = moveDir;
        }

        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, maxDistance, counterLayerMask))
            if (raycastHit.transform.TryGetComponent(out Counter clearCounter))
                clearCounter.Interact();
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 vector = inputManager.GetMovementVector();

        Vector3 moveDir = new Vector3(vector.x, 0f, vector.y);

        isWalking = moveDir != Vector3.zero;

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any directionVector2 vector = inputManager.GetMovementVector(); 
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * ROTATE_SPEED);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
