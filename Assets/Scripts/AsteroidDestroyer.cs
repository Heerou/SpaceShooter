using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour {

    private void OnEnable() {
        Invoke("AwesomeAsteroidDestroyer", 2f);
    }


    void AwesomeAsteroidDestroyer() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }
}
