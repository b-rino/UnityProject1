using UnityEngine;

public class MakeTextAppear : MonoBehaviour
{
    private GameObject TextHolder;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        animator = GetComponent<Animator>();
        TextHolder = transform.Find("TextHolder").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetTextStatus(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetTextStatus(false);
        }
    }

    public void SetTextStatus(bool value)
    {
        animator.SetBool("IsEnabled", value);
    }
}
