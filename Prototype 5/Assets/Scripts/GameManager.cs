using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public List<GameObject> targets;

    [Space] 
    
    [SerializeField] float spawnRate;
    
    void Start() {
        StartCoroutine(this.SpawnTarget());
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
