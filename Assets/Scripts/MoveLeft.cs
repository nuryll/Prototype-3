using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;

    private float leftBound = -15; // Left boundary for destroying the object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) {

            transform.Translate(Vector3.left * Time.deltaTime * speed); // Move the object to the left at a constant speed
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // If the object has moved beyond the left boundary and is an obstacle
        {
            Destroy(gameObject); // Destroy the object to free up memory
        }
    }
}
