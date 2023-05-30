using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;
    private bool isWalking;

    void Update()
    {
        var direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
            direction.z -= 1;
        if (Input.GetKey(KeyCode.A))
            direction.x -= 1;
        if (Input.GetKey(KeyCode.D))
            direction.x += 1;

        direction = direction.normalized;

        isWalking = direction != Vector3.zero;
        var rotateSpeed = 10f;
        transform.position += moveSpeed * Time.deltaTime * direction;
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
