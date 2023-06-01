using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private InputManager inputManager = null;
    private bool isWalking;

    void Update()
    {
        Vector3 vector = inputManager.GetMovementVector();
        isWalking = vector != Vector3.zero;
        var rotateSpeed = 10f;
        transform.position += moveSpeed * Time.deltaTime * vector;
        transform.forward = Vector3.Slerp(transform.forward, vector, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
