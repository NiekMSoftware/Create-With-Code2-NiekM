using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float speed;
    
    // Private vars.
    Rigidbody _enemyRb;
    GameObject _player;
    

    void Start() {
        this._enemyRb = this.GetComponent<Rigidbody>();
        this._player = GameObject.Find("Player");
    }

    void Update() {
        // Make the enemy look at the player
        Vector3 lookDir = this._player.transform.position - transform.position;
    
        // Push the enemy forward based on the look direction
        this._enemyRb.AddForce(lookDir.normalized * this.speed);
    
        // Destroy the enemies once they fall
        if (transform.position.y < -25) {
            Destroy(gameObject);
        }
    }
}
