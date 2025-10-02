using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;

    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; // Modify the gravity in the game

    }

    // Update is called once per frame
    void Update()
    {
        // Jump when space is pressed. GetKeyDown only triggers once when the key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //impulse gives an instant force. ForceMode.Force gives a continuous force
            isOnGround = false; // Player is no longer on the ground after jumping
        }

        


    }

    private void OnCollisionEnter(Collision collision)
    {
        
        isOnGround = true; // Player is on the ground
        
    }
}
