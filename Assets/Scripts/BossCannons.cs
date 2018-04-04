using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannons : MonoBehaviour {

    public GameObject Bullet;
    public Transform ShotSpawn;
    float fireRate = 0.5f;
    float nextFire = 0.5f;

    public int PooledBullets = 10;
    List<GameObject> bullets;

    AudioSource weaponAudio;


    // Use this for initialization
    void Start () {
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
        Shooting();
    }

    void Shooting() {
        for (int i = 0; i < bullets.Count; i++) {
            if (!bullets[i].activeInHierarchy) {
                if (Time.time > nextFire) {
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
