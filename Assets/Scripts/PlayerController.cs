using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    [SerializeField] private TextMeshProUGUI gameOverText; // Reference to the Game Over text UI element


    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, -9.81f, 0) * gravityModifier; 
        playerAudio = GetComponent<AudioSource>();// Get the AudioSource component attached to the player

        if (gameOverText != null)
        {
            gameOverText.enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // Jump when space is pressed. GetKeyDown only triggers once when the key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //impulse gives an instant force. ForceMode.Force gives a continuous force
            isOnGround = false; // Player is no longer on the ground after jumping
            playerAnim.SetTrigger("Jump_trig"); // Trigger the jump animation
            dirtParticle.Stop(); // Stop the dirt particle effect when jumping
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground")) // If player collides with the ground
        {
            isOnGround = true; // Player is back on the ground
            dirtParticle.Play(); // Play the dirt particle effect when back on the ground
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // If player collides with an obstacle
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true); // Trigger the death animation
            playerAnim.SetInteger("DeathType_int", 1); // Set the death type to 1
            explosionParticle.Play(); // Play the explosion particle effect
            dirtParticle.Stop(); // Stop the dirt particle effect when game is over
            playerAudio.PlayOneShot(crashSound, 1.0f);

            if (gameOverText != null)
            {
                gameOverText.text = "GAME OVER! \n\n" +
                    "Press R to Restart";
                gameOverText.enabled = true;
            }
        }

        


    }
}
