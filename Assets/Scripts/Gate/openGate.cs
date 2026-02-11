using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator animator;        // Reference til Animator på porten
    public string openTriggerName = "Open";  // Navnet på triggeren i Animator
    public float interactDistance = 3f;      // Hvor tæt spilleren skal være

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(openTriggerName);
        }
    }
}
