using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Rigidbody objRB;
    public float Speed;

	// Use this for initialization
	void Start () {
        objRB = GetComponent<Rigidbody>();
        objRB.velocity = transform.up * Speed;
    }
}
