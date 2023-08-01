using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Player's RigidBody
    Rigidbody _playerRb;
    Animator _playerAnim;
    
    [Header("Jump Variables")]
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isGrounded = true;

    [Header("Particles")]
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem runParticle;

    [Header("SFX")] 
    [SerializeField] AudioClip jumpSfx;
    [SerializeField] AudioClip crashSfx;
    [SerializeField] AudioSource _playerAudio;

    [Space] 

    public bool gameOver;
    
    void Start() {
        // Automatically get the Rigidbody at Start of Game
        this._playerRb = this.GetComponent<Rigidbody>();
        
        // Get the Animator component
        this._playerAnim = this.GetComponent<Animator>();
        
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
        if (Input.GetKeyDown(KeyCode.Space) && this.isGrounded && !this.gameOver) {
            // Force the player up multiplied by the jumpForce
            this._playerRb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            
            // Once in the air Player is not grounded
            this.isGrounded = false;
            
            // Play animation
            this._playerAnim.SetTrigger("Jump_trig");
            
            // Stop the particle system
            this.runParticle.Stop();
            
            // Play the Sfx
            this._playerAudio.PlayOneShot(this.jumpSfx, 1.0f);
        }
    }
    
    void OnCollisionEnter(Collision other) {
        // Check if the Player hit the Ground or Obstacle
        if (other.gameObject.CompareTag("Ground")) {
            this.isGrounded = true;
            
            // Turn on the particles again
            this.runParticle.Play();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            this.gameOver = true;
            
            // Set the animation
            this._playerAnim.SetBool("Death_b", true);
            this._playerAnim.SetInteger("DeathType_int", 1);
            
            // Play the explosion particle system
            this.explosionParticle.Play();
            
            // Stop the running particles
            this.runParticle.Stop();
            
            // Play the SFX for crashing
            this._playerAudio.PlayOneShot(this.crashSfx, 1.0f);
        }
    }
}
