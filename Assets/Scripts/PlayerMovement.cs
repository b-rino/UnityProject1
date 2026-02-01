using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    private Rigidbody rb;
    private Vector3 inputDirection;

    void Start()
    {
        // transform.root er PlayerBase
        rb = transform.root.GetComponentInChildren<Rigidbody>();
      
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(h, 0, v).normalized;
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = transform.TransformDirection(inputDirection) * moveSpeed;

        Vector3 velocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
