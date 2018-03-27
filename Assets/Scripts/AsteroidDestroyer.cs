using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour {

    public float LifeTime;

	// Use this for initialization
	void Start () {
        AwesomeAsteroidDestroyer();
    }
	
	
    void AwesomeAsteroidDestroyer() {
        Destroy(gameObject, LifeTime);
    }
}
