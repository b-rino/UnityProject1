using UnityEngine;

public class DoghouseDamage : MonoBehaviour
{
    public float damagePercent = 0.2f; // 20%

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
