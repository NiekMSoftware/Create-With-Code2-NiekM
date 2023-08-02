using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject powerUp;

    [Space] 
    
    public int waveNumber;
    int _enemyCount;
    
    // private vars.
    float _spawnRange = 9f;

    GameManager _gameManager;

    void Start() {
        this.SpawnEnemyWave(this.waveNumber);
        
        // Spawn in Powerup
        Instantiate(this.powerUp, this.GeneratePosition(), this.powerUp.transform.rotation);
        
        // Get the game manager Object
        this._gameManager = GameObject.Find("Game State Manager").GetComponent<GameManager>();
    }

    void Update() {
        if (!this._gameManager.gameOver) {
            // Count all the enemies
            this._enemyCount = FindObjectsOfType<Enemy>().Length;

            if (this._enemyCount == 0) {
                // Add a new wave
                this.waveNumber++;
                SpawnEnemyWave(this.waveNumber);
            
                // Spawn in a new Powerup
                Instantiate(this.powerUp, this.GeneratePosition(), this.powerUp.transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            // Spawn in the enemy
            Instantiate(this.enemy, this.GeneratePosition(), this.enemy.transform.rotation);
        }
    }
    
    Vector3 GeneratePosition() {
        // Randomize both X and Z positions
        float spawnPosX = Random.Range(-this._spawnRange, this._spawnRange);
        float spawnPosZ = Random.Range(-this._spawnRange, this._spawnRange);
        
        // Randomize the position
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        // Return the randomized value
        return randomPos;
    }
}
