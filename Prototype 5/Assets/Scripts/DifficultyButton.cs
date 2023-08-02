using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
    Button _button;
    
    // Get the game manager
    GameManager _gameManager;

    public int difficulty;

    void Start() {
        this._button = this.GetComponent<Button>();
        
        // Listen to a click
        this._button.onClick.AddListener(this.SetDifficulty);
        
        // Get the game manager component
        this._gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty() {
        Debug.Log(gameObject.name + " was called!");
        
        // Start the game
        this._gameManager.StartGame(this.difficulty);
    }
}
