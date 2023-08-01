using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {
    // Start position Var
    Vector3 _startPos;
    float _repeatWidth;

    void Start() {
        // Set our start Position to it's current position
        this._startPos = transform.position;
        
        // Set the repeat width to half of the Collider
        this._repeatWidth = this.GetComponent<BoxCollider>().size.x / 2;
    }

    void Update() {
        // Check if the position is less than the half of the Collider
            // Based off the start position
        if (transform.position.x < this._startPos.x - this._repeatWidth) {
            // Reset it's position back to the starting position
            transform.position = this._startPos;
        }
    }
}
