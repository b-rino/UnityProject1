using UnityEngine;

public class TeleportNode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TeleportHere(GameObject toTeleport)
    {
        toTeleport.transform.position = transform.position;
    }
    
}
