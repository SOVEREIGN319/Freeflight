using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f; // Enemy movement speed

    private void Update()
    {
        // Move the enemy down the screen
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the enemy collides with "pfBullet"
        Debug.Log($"Collided with: {collision.gameObject.name}");

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet hit detected!");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

