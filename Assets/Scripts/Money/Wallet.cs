using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }

    public event Action<int> OnMoneyChanged;

    [SerializeField] private int money = 0;
    public int Money => money;

    private void Awake()
    {
        Debug.Log("[Wallet] Awake on: " + gameObject.name);
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void Add(int amount)
    {
        Debug.Log("[Wallet] Add called: +" + amount);
        if (amount <= 0) return;
        money += amount;
        Debug.Log("[Wallet] New money = " + money + " (invoking event)");
        OnMoneyChanged?.Invoke(money);
    }
}
