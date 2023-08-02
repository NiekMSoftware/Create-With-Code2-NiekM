using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;
    int _score;
    
    [Space]
    
    [SerializeField] TextMeshProUGUI scoreText;
    
    [Space]
    
    [SerializeField] float spawnRate;
    
    void Start() {
        StartCoroutine(this.SpawnTarget());

        this._score = 0;
    }

    public void UpdateScore(int scoreToAdd) {
        this._score += scoreToAdd;
        this.scoreText.text = "Score: " + this._score;
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
