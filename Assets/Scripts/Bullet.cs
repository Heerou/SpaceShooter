using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int Damage;
    public string TagToFind;

    Rigidbody bulletRB;
    public float Speed;

    void Start() {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TagToFind)) {
            other.GetComponent<LifeComponent>().TakeDamage(Damage);
            SetState(false);
        }
    }

    void SetState(bool state) {
        gameObject.SetActive(state);
    }
}
