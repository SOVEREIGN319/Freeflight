using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 5f; // Speed at which the bullet moves
    public float lifetime = 3f; // Time after which the bullet is destroyed

    private void Start()
    {
        // Destroy the bullet after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet upward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}