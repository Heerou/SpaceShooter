using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int Damage;
    public string TagToFind;

    public bool AmIAsteroid;

    Rigidbody bulletRB;
    public float Speed;

    public ParticleSystem Explosion;

    void Start() {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * Speed;

        Explosion = (ParticleSystem)Instantiate(Explosion);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TagToFind)) {
            other.GetComponent<LifeComponent>().TakeDamage(Damage);
            SetState(false);
            Explosion.transform.position = transform.position;
            Explosion.Play();
        }
        if (AmIAsteroid) {
            SetState(false);
            Explosion.transform.position = transform.position;
            Explosion.Play();
        }
    }

    void SetState(bool state) {
        gameObject.SetActive(state);
    }
}
