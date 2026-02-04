using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float acceleration = 10f;

    private Rigidbody rb;
    private Vector3 inputDirection;

    public Transform playerBase;

    private bool isSprinting;

    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(h, 0, v).normalized;

        // Sprint = bare hurtigere run
        isSprinting = Input.GetKey(KeyCode.LeftShift) && inputDirection.magnitude > 0;

        // Animator får kun speed
        animator.SetFloat("speed", rb.linearVelocity.magnitude);
    }

    void FixedUpdate()
    {
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector3 targetVelocity = playerBase.TransformDirection(inputDirection) * currentSpeed;

        Vector3 velocity = Vector3.Lerp(
            rb.linearVelocity,
            targetVelocity,
            acceleration * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
