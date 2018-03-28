﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    float moveHorizontal;
    float moveVertical;
    Rigidbody playerRB;
    public Boundary boundary;
    public GameObject Bullet;
    public Transform ShotSpawn;
    float fireRate = 0.5f;
    float nextFire = 0.5f;
    AudioSource weaponAudio;

    public int PooledBullets = 5;
    List<GameObject> bullets;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody>();
        weaponAudio = GetComponent<AudioSource>();

        bullets = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < PooledBullets; i++) {
            obj = (GameObject)Instantiate(Bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        RestictionZone();
        ShipRot();
        Shooting();
    }

    //Movimiento del personaje
    void Movement () {        
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRB.velocity = movement * Speed;
    }

    //para que el jugador no se salga de la camara
    void RestictionZone () {
        playerRB.position = new Vector2(
            Mathf.Clamp(playerRB.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(playerRB.position.y, boundary.yMin, boundary.yMax)
        );
    }

    //Rotacion de la nave en el eje y
    void ShipRot () {
        float titl = 4;
        playerRB.rotation = Quaternion.Euler(-90, playerRB.velocity.x * -titl, 0);
    }

    //Disparo
    void Shooting () {
        for(int i = 0; i < bullets.Count; i++) {
            if (!bullets[i].activeInHierarchy) {
                if (Input.GetButton("Fire1") && Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    bullets[i].transform.position = ShotSpawn.position;
                    bullets[i].transform.rotation = ShotSpawn.rotation;
                    bullets[i].SetActive(true);
                    weaponAudio.Play();
                    break;
                }
            }
        }   
    }
}
