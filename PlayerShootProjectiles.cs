using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Position where the bullet will spawn

    private bool canShoot = true; // Flag to ensure only one bullet is fired at a time

    private void Update()
    {
        // Check if the Spacebar is pressed and the player can shoot
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet at the spawn point's position and rotation
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Disable shooting until the bullet is destroyed
        canShoot = false;

        // Re-enable shooting after a short delay
        Invoke(nameof(ResetShoot), 0.35f); // Adjust delay as needed
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
