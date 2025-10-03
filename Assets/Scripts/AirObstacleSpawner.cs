using UnityEngine;

public class AirObstacleSpawner : MonoBehaviour
{
    public GameObject airObstaclePrefab;
    private Vector3 spawnPos = new Vector3(30, 10, 0);
    private float startDelay = 3;
    private float repeatRate = 3;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(airObstaclePrefab, spawnPos, airObstaclePrefab.transform.rotation);
        }
    }
}

