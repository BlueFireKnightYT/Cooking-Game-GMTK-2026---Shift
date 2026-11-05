using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody rb;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(moveInput.y, 0, moveInput.x) * speed;
    }

    public void GetMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
