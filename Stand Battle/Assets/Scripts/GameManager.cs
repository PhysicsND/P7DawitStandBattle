using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ground;

    private float leftBound;

    public GameObject enemyPrefab;
    public GameObject player;

    public Vector3 spawnPosition = new Vector3(8, -4, -3);

    void Start()
    {
        // Get left edge of the ground
        Renderer groundRenderer = ground.GetComponent<Renderer>();

        leftBound = ground.transform.position.x
                    - (groundRenderer.bounds.size.x / 2);

        // Spawn enemy
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            enemyPrefab.transform.rotation
        );

        // Give enemy the player reference
        newEnemy.GetComponent<Enemy>().player = player;
    }

    void Update()
    {
        // Find all game objects
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Skip the ground itself
            if (obj.CompareTag("Ground"))
            {
                continue;
            }

            // Destroy objects that leave the left side
            if (obj.transform.position.x < leftBound)
            {
                Destroy(obj);
            }
        }
    }
}