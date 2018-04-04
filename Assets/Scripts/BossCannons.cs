using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannons : LifeComponent {

    public GameObject Bullet;
    public Transform ShotSpawn;
    float fireRate = 0.5f;
    float nextFire = 0.5f;
    int currentBullet;

    public int PooledBullets = 10;
    List<GameObject> bullets;

    AudioSource weaponAudio;

    GameObject FatherEnemyBullets;


    // Use this for initialization
    void Start () {
        weaponAudio = GetComponent<AudioSource>();
        FatherEnemyBullets = new GameObject("EnemyBullets");

        bullets = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < PooledBullets; i++) {
            obj = (GameObject)Instantiate(Bullet);
            obj.SetActive(false);
            bullets.Add(obj);
            obj.transform.SetParent(FatherEnemyBullets.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Shooting();
    }

    void Shooting() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            bullets[currentBullet].transform.position = ShotSpawn.position;
            bullets[currentBullet].transform.rotation = ShotSpawn.rotation;
            bullets[currentBullet].SetActive(true);
            weaponAudio.Play();
        }
        currentBullet++;
        if (currentBullet >= bullets.Count) {
            currentBullet = 0;
        }
    }

    public override void Muerte() {
        base.Muerte();
        gameObject.SetActive(false);
    }
}
