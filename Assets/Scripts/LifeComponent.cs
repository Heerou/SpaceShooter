using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour {

    public int Hp;
	
    public void TakeDamage (int damage) {
        Hp -= damage;

        if(Hp < 1) {
            Debug.Log("Te moristeis wey!");
        }
    }
}
