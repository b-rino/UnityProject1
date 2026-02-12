using UnityEngine;

public class ChestLoot : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    [SerializeField] private int moneyAmount = 50;
    private bool isLooted = false;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && !isLooted && Input.GetKeyDown(KeyCode.F))
        {
            LootChest();
        }
    }

    void LootChest()
    {
        isLooted = true;

        Debug.Log("[Chest] LootChest. Wallet.Instance is " + (Wallet.Instance == null ? "NULL" : "OK"));

        if (Wallet.Instance != null)
        {
            Wallet.Instance.Add(moneyAmount);
            Debug.Log("Added '" + moneyAmount + "' gold.");
        }

        if (coins != null)
            coins.SetActive(false);

        Debug.Log("Chest looted!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press F to loot");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
