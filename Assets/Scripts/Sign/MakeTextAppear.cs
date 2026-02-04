using UnityEngine;

public class MakeTextAppear : MonoBehaviour
{
    private GameObject TextHolder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextHolder = transform.Find("TextHolder").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextHolder.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextHolder.SetActive(false);
        }
    }
}
