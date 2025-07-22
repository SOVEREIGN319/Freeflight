using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public Transform[] lines; // Array of line positions (set these in the Inspector)
    public float spawnInterval; // Time interval between spawns

    private void Start()
    {
        // Start spawning enemies at regular intervals
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (lines.Length == 0)
        {
            Debug.LogError("No lines assigned to the EnemySpawner script.");
            return;
        }

        // Choose a random line
        int randomLineIndex = Random.Range(0, lines.Length);
        Vector3 spawnPosition = lines[randomLineIndex].position;

        // Adjust the spawn position's y to be above the screen (e.g., y = 10)
        spawnPosition.y = 10;

        // Instantiate the enemy at the chosen line
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
