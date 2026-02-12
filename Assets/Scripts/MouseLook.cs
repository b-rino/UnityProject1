using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraRotationPoint; // Main Camera rotation axis
    public Transform cameraTransform; // Main Camera position
    public Transform playerBase;      // PlayerBase
    public float sensitivity = 2f;
    public float minPitch = -40f;
    public float maxPitch = 60f;
    public float cameraDistance = 6.5f;
    
    

    private float yaw = 0f;
    private float pitch = 0f;
    private LayerMask layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Default");
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;;

        // Horisontal rotation (PLAYERBASE)
        yaw += mouseX;
        playerBase.rotation = Quaternion.Euler(0, yaw, 0);

        // Vertikal rotation (Main Camera)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraRotationPoint.localRotation = Quaternion.Euler(pitch, 0, 0);
        
        Vector3 rayDirection =  (cameraTransform.position - cameraRotationPoint.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(cameraRotationPoint.position, transform.TransformDirection(rayDirection), out hit, cameraDistance, layerMask))
        {
            cameraTransform.localPosition  = new Vector3(0,0,-hit.distance);
        }
        else
        {
            cameraTransform.localPosition  = new Vector3(0,0,-cameraDistance);
        }
    }
}
