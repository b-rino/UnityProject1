using UnityEngine;

public class CarDamage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damagePercent = 0.1f; // 10%

private void OnCollisionEnter(Collision collision)
{
    Transform root = collision.transform.root;

    if (root.CompareTag("Player"))
    {
        PlayerHealth health = root.GetComponent<PlayerHealth>();
        if (health != null)
        {
            float damage = health.maxHealth * damagePercent;
            health.TakeDamage(damage);
        }
    }
}
}
