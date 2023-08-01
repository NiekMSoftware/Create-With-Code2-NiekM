using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    [SerializeField] float speed;

    PlayerController _player;
    
    // Left bound for Obstacles
    float _leftBound = -15f;

    void Start() {
        // Find the Player GameObject and grab it's script
        this._player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() {
        // Check if the game is still running
        if (this._player.gameOver == false) {
            // Move the obstacle to the left
            transform.Translate(Vector3.left * (this.speed * Time.deltaTime));
        }
        
        // Check if it is the obstacle that is out of bounds and destroy it
        if (transform.position.x < this._leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
