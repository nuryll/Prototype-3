using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0); // position where the obstacles will be spawned
    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // call SpawnObstacle method every 2 seconds after an initial delay of 2 seconds
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        { Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); }// spawn an obstacle at the spawn position with the same rotation as the prefab
    }
}
