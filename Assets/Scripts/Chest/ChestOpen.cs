using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] private GameObject openChest;
    [SerializeField] private GameObject coins;

    private bool isOpen = false;
    private bool playerInRange = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerInRange && !isOpen && Input.GetKeyDown(KeyCode.F))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpen = true;

        if (animator != null)
        {
            animator.SetTrigger("Open");
        }

        Invoke(nameof(SwapToOpenChest), 0.5f);
    }

    void SwapToOpenChest()
    {
        if (openChest != null)
        {
            openChest.SetActive(true);
            coins.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press F to open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
