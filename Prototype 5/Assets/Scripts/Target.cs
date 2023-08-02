using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour {
    Rigidbody _targetRb;

    // Speed vars.
    float _minSpeed = 12f;
    float _maxSpeed = 16f;
    
    // Force for rotation
    float _maxTorque = 12f;
    
    // Range
    float _xRange = 4f;
    float _ySpawnPos = -6f;

    GameManager _gameManager;
    
    // Point value
    [SerializeField] int pointValue;
    [SerializeField] ParticleSystem explosionParticle;

    void Start() {
        this._targetRb = this.GetComponent<Rigidbody>();
        
        // Throw the Target up
        this._targetRb.AddForce(this.RandomForce(), ForceMode.Impulse);
        
        // Rotate the Target
        this._targetRb.AddTorque(this.RandomTorque(), this.RandomTorque(), this.RandomTorque(), 
                                    ForceMode.Impulse);
        
        // Randomize spawn Position
        transform.position = this.RandomSpawnPos();

        // Get the Game Manager
        this._gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnMouseDown() {
        Destroy(gameObject);
        
        // Update Score when clicked on
        this._gameManager.UpdateScore(this.pointValue);
        
        // Spawn in the particle system
        Instantiate(this.explosionParticle, transform.position, this.explosionParticle.transform.rotation);
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(this._minSpeed, this._maxSpeed);
    }

    float RandomTorque() {
        return Random.Range(-this._maxTorque, this._maxTorque);
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-this._xRange, this._xRange), this._ySpawnPos);
    }

    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
