using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : LifeComponent {

    public Boundary boundary;
    public float Speed;
    Rigidbody bossRB;

    public string TagToFind;
    public int Damage;

    // Use this for initialization
    void Start() {
        gameObject.SetActive(false);
        bossRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        RestictionZone();
    }

    public void Movement() {
        gameObject.SetActive(true);
        StartCoroutine(Mover(transform, new Vector3 (0, 6, 0)));
    }

    void RestictionZone() {
        bossRB.position = new Vector2(
            Mathf.Clamp(bossRB.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(bossRB.position.y, boundary.yMin, boundary.yMax)
        );
    }

    IEnumerator Mover(Transform transitionObject, Vector3 finalPos) {
        float t = 0;
        Vector3 initialPos = transitionObject.position;
        while (t < 1) {
            transitionObject.position = Vector3.Lerp(initialPos, finalPos, t);
            t += Time.deltaTime * Speed;
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
