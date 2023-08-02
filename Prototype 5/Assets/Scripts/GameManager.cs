using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public bool isGameActive;
    
    public List<GameObject> targets;
    int _score;
    
    [Header("GUI")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI gameOverText;
    
    [Space]
    
    [SerializeField] float spawnRate;
    
    void Start() {
        StartCoroutine(this.SpawnTarget());

        this._score = 0;

        this.isGameActive = true;
    }

    public void UpdateScore(int scoreToAdd) {
        this._score += scoreToAdd;
        this.scoreText.text = "Score: " + this._score;
    }

    public void GameOver() {
        this.gameOverText.gameObject.SetActive(true);
        
        // Turn off the boolean
        this.isGameActive = false;
        
        // Turn on the gameobject of restarting the game
        this.restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(this.spawnRate);
            
            // Grab a random target from the List
            int index = Random.Range(0, this.targets.Count);
            
            // Spawn in Target
            Instantiate(this.targets[index]);
        }
    }
}
