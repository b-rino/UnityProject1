using UnityEngine;

public class FreeMove : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float lookSpeed = 2f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Update()
    {
        // Mouse look
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -80f, 80f);

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Shift = sprint
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        Vector3 move = transform.forward * v + transform.right * h;
        transform.position += move * currentSpeed * Time.deltaTime;
    }
}

