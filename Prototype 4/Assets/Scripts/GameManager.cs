using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool gameOver;
    
    SpawnManager _spawnManager;
    
    
    void Start() {
        this._spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update() {
        if (this.gameOver) {
            this.ResetScene();
        }
    }

    public void ResetScene() {
        this._spawnManager.waveNumber = 1;
    }
}
