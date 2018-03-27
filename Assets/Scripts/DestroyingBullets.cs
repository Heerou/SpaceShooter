using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingBullets : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        BulletDestroyer();
	}

    void BulletDestroyer () {
        //Destruyo el la bala despues de 2 frames
        Destroy(gameObject, 2f);
    }
}
