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

    void Start() {
        this.InvokeRepeating("SpawnObstacles", this._startDelay, this._repeatRate);
    }

    void SpawnObstacles() {
        // Randomize the objects
        int obstacleIndex = Random.Range(0, this.obstaclePrefabs.Length);
        
        Instantiate(this.obstaclePrefabs[obstacleIndex], this._spawnPos, 
            this.obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
