using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPowerup : MonoBehaviour {
    public float rotationSpeed;

    void Update() {
        transform.Rotate(Vector3.up * (this.rotationSpeed * Time.deltaTime));
    }
}
