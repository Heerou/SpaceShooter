using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    Rigidbody bulletRB;
    public float Speed;

    // Use this for initialization
    void Start() {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * Speed;
    }
}
