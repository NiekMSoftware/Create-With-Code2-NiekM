using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
    [SerializeField] float speed;

    void Update() {
        // Move the obstacle to the left
        transform.Translate(Vector3.left * (this.speed * Time.deltaTime));
    }
}
