using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

        var rotateSpeed = 10f;
        transform.position += moveSpeed * Time.deltaTime * direction;
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
    }
}
