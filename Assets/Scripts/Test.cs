using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with: " + collision.gameObject.name);
    }
}
