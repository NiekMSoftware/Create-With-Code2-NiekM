using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Player's RigidBody
    Rigidbody _playerRb;
    
    [Header("Jump Variables")]
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isGrounded = true;

    [Space]
    public bool gameOver;
    
    void Start() {
        // Automatically get the Rigidbody at Start of Game
        this._playerRb = this.GetComponent<Rigidbody>();
        
        // Multiply our Physics' Gravity by the modifier
        Physics.gravity *= this.gravityModifier;
    }

    void Update() {
        if (this.gameOver == false) {
            this.Jump();
        }
    }

    void Jump() {
        // Jump once the player hit the Space key
        if (Input.GetKeyDown(KeyCode.Space) && this.isGrounded) {
            // Force the player up multiplied by the jumpForce
            this._playerRb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            
            // Once in the air Player is not grounded
            this.isGrounded = false;
        }
    }
    
    void OnCollisionEnter(Collision other) {
        // Check if the Player hit the Ground or Obstacle
        if (other.gameObject.CompareTag("Ground")) {
            this.isGrounded = true;
        } else if (other.gameObject.CompareTag("Obstacle")) {
            this.gameOver = true;
        }
    }
}
