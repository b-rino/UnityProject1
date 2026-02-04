using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;    // PlayerBase
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
