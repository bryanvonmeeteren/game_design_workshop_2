using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    public float movementSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnMove(InputValue value)
    {
        Vector2 movementValue =  value.Get<Vector2>();
        moveX = movementValue.x;
        moveY = movementValue.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.AddForce(movement * movementSpeed);
    }
}
