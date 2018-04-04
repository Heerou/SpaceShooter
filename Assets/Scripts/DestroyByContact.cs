using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject Explosion;
    public int ScoreValue;
    GameController gameController;

    public string TagToFind;

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
        if(other.CompareTag(TagToFind)) {
            Instantiate(Explosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        gameController.AddScore(ScoreValue);
    }
}
