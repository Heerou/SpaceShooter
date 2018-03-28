using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject Explosion;
    public int ScoreValue;
    GameController gameController;

    private void Start() {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if(gameControllerObj != null) {
            gameController = gameControllerObj.GetComponent<GameController>();
        } else {
            Debug.Log("No hay gameController");
        }
    }

    //Cuando se tocan explotan
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet") {
            Instantiate(Explosion, other.transform.position, other.transform.rotation);
            gameObject.SetActive(false);
        }
        if(other.tag == "Player") {
            Instantiate(Explosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        gameController.AddScore(ScoreValue);
    }
}
