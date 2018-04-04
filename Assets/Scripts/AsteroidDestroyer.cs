using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : LifeComponent {

    private void OnEnable() {
        Invoke("AwesomeAsteroidDestroyer", 2f);
    }


    void AwesomeAsteroidDestroyer() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }

    public override void Muerte() {
        base.Muerte();
        AwesomeAsteroidDestroyer();
    }
}
