using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Array of GameObjects
    [SerializeField] GameObject[] obstaclePrefabs;
    
    // Spawn position of obstacles
    Vector3 _spawnPos = new Vector3(20, 0, 0);
    
    // Interval floats
    float _startDelay = 2;
    float _repeatRate = 3.5f;

    // Player Controller script
    PlayerController _playerController;

    void Start() {
        this.InvokeRepeating("SpawnObstacles", this._startDelay, this._repeatRate);
        
        // Get the Player object and it's Controller
        this._playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacles() {
        // Check if it isn't game over
        if (this._playerController.gameOver == false) {
            // Randomize the objects
            int obstacleIndex = Random.Range(0, this.obstaclePrefabs.Length);
        
            // Spawn in randomized Obstacles
            Instantiate(this.obstaclePrefabs[obstacleIndex], this._spawnPos, 
                this.obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
