using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraTransform; // Main Camera
    public Transform playerBase;      // PlayerBase
    public float sensitivity = 2f;
    public float minPitch = -40f;
    public float maxPitch = 60f;

    float yaw = 0f;
    float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Horisontal rotation (PLAYERBASE)
        yaw += mouseX;
        playerBase.rotation = Quaternion.Euler(0, yaw, 0);

        // Vertikal rotation (Main Camera)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
