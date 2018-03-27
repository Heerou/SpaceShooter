using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    Rigidbody asteroidRB;

	// Use this for initialization
	void Start () {
        asteroidRB = GetComponent<Rigidbody>();
        asteroidRB.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
