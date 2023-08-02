using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // private vars.
    Rigidbody _playerRb;
    GameObject _focalPoint;
    float _randomNum;
    
    [SerializeField] float speed;

    [Space] 
    
    [SerializeField] GameObject missile;
    
    [Space]
    
    [SerializeField] GameObject powerUpIndicator;
    [SerializeField] float powerUpStrength;
    [SerializeField] int powerUpCountdown;
    [SerializeField] bool hasPowerUp;

    void Start() {
        this._playerRb = this.GetComponent<Rigidbody>();
        this._focalPoint = GameObject.Find("Focal Point");
    }

    void Update() {
        // Save the forward input
        float forwardInput = Input.GetAxis("Vertical");
       
        // Push the player forward based on the focal point
        this._playerRb.AddForce(this._focalPoint.transform.forward * (this.speed * forwardInput));
    
        // Set the position of where it should be
        this.powerUpIndicator.transform.position = transform.position;
    }

    void OnTriggerEnter(Collider other) {
        // Check if triggered a powerup
        if (other.CompareTag("Powerup")) {
            // Generate random number
            this._randomNum = Random.Range(0, 3);
            
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
