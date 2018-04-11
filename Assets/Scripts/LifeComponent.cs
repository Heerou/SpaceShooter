using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour {

    public int Hp;
    public int ScoreValue;
    GameController gameController;
    GameObject gameControllerObj;

    private void Start() {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObj != null) {
            gameController = gameControllerObj.GetComponent<GameController>();
        } else {
            Debug.Log("No hay GameController");
        }
    }

    public virtual void TakeDamage(int damage) {
        Hp -= damage;

        if (Hp < 1) {
            Debug.Log("Te moristeis wey!");
            Muerte();
        }
    }

    public virtual void Muerte() {
        gameController.AddScore(ScoreValue);
    }
}
