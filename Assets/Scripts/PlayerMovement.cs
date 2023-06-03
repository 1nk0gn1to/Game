using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float ROTATE_SPEED = 10f;
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private InputManager inputManager = null;
    private bool isWalking;

    void Update()
    {
        Vector2 vector = inputManager.GetMovementVector();

        Vector3 moveDir = new Vector3(vector.x, 0f, vector.y);
        
        isWalking = moveDir != Vector3.zero;

        transform.position += moveSpeed * Time.deltaTime * moveDir;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * ROTATE_SPEED);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
