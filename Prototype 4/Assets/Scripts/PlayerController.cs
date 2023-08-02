using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // private vars.
    Rigidbody _playerRb;
    GameObject _focalPoint;
    
    [SerializeField] float speed;

    [Space]
    
    [SerializeField] GameObject powerUpIndicator;
    [SerializeField] float powerUpStrength;
    [SerializeField] int powerUpCountdown;
    [SerializeField] bool hasPowerUp;

    GameManager _gameManager;

    void Start() {
        this._playerRb = this.GetComponent<Rigidbody>();
        this._focalPoint = GameObject.Find("Focal Point");
        this._gameManager = GameObject.Find("Game State Manager").GetComponent<GameManager>();
    }

    void Update() {
        // Save the forward input
        float forwardInput = Input.GetAxis("Vertical");

        if (!this._gameManager.gameOver) {
            // Push the player forward based on the focal point
            this._playerRb.AddForce(this._focalPoint.transform.forward * (this.speed * forwardInput));
        
            // Set the position of where it should be
            this.powerUpIndicator.transform.position = transform.position;
            
            if (transform.position.y < -25f) {
                this._gameManager.gameOver = true;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        // Check if triggered a powerup
        if (other.CompareTag("Powerup")) {
            this.hasPowerUp = true;
            Destroy(other.gameObject);
            
            // Activate the thread Routine
            StartCoroutine(this.PowerupCountdownRoutine());
            
            // Activate the Gameobject
            this.powerUpIndicator.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other) {
        // Check if the player collided with an Enemy
        if (other.gameObject.CompareTag("Enemy") && this.hasPowerUp) {
            // Grab the Rigidbody and Distance of the enemy
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 distancePlayer = other.gameObject.transform.position - transform.position;
            
            // DEBUG
            Debug.Log("Collided with " + other.gameObject.name + " with Power-up set to " + this.hasPowerUp);
            
            // Push the enemy away with the power-up force
            enemyRb.AddForce(distancePlayer * this.powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        // Count down Seconds, then turn off Routine
        yield return new WaitForSeconds(this.powerUpCountdown);
        this.hasPowerUp = false;
        
        // Turn off the indicator
        this.powerUpIndicator.SetActive(false);
    }
}
