using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerHealth health;

    public void EndDance()
    {
        movement.EndDance();
    }

    public void ApplyDanceDamage()
    {
        float damage = health.maxHealth * 0.5f;
        health.TakeDamage(damage);
    }
}
