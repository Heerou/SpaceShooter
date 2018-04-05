using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : LifeComponent {

    public float Speed;
    public float SideSpeed;

    public string TagToFind;
    public int Damage;

    int r;

    public bool Down;

    // Use this for initialization
    void Start() {
        gameObject.SetActive(false);
    }


    public void ActivateBoss() {
        gameObject.SetActive(true);
        StartCoroutine(Activation());
    }

    IEnumerator Activation() {
        yield return StartCoroutine(Mover(transform, new Vector3(0, 6, 0), Speed));

        while (Hp > 0) {
            yield return StartCoroutine(Mover(transform, new Vector3(3, 6, 0), SideSpeed));
            r = Random.Range(0, 100);
            if (r < 30) {
                Down = true;
                yield return StartCoroutine(Mover(transform, new Vector3(3, -4, 0), SideSpeed));
                yield return StartCoroutine(Mover(transform, new Vector3(3, 6, 0), SideSpeed));
                Down = false;
            }
            yield return StartCoroutine(Mover(transform, new Vector3(-3, 6, 0), SideSpeed));
            r = Random.Range(0, 100);
            if (r < 30) {
                Down = true;
                yield return StartCoroutine(Mover(transform, new Vector3(-3, -4, 0), SideSpeed));
                yield return StartCoroutine(Mover(transform, new Vector3(-3, 6, 0), SideSpeed));
                Down = false;
            }
        }
    }

    IEnumerator Mover(Transform transitionObject, Vector3 finalPos, float speed) {
        float t = 0;
        Vector3 initialPos = transitionObject.position;
        while (t < 1) {
            transitionObject.position = Vector3.Lerp(initialPos, finalPos, t);
            t += Time.deltaTime * speed;
            yield return null;
        }
        transitionObject.position = Vector3.Lerp(initialPos, finalPos, 1);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TagToFind)) {
            other.GetComponent<LifeComponent>().TakeDamage(Damage);
        }
    }

    public override void Muerte() {
        base.Muerte();
        gameObject.SetActive(false);
    }
}
