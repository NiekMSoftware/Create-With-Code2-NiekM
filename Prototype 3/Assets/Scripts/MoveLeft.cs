using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    [SerializeField] float speed;

    PlayerController _player;

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
    }
}
