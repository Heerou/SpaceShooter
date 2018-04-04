using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour {

    public int Hp;

    public virtual void TakeDamage(int damage) {
        Hp -= damage;

        if (Hp < 1) {
            Debug.Log("Te moristeis wey!");
            Muerte();
        }
    }

    public virtual void Muerte() {

    }
}
