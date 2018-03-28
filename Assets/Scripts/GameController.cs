using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject Asteroids;
    public Vector2 SpawnValues;
    public int PooledAsteroids;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    bool restart;
    bool gameOver;
    int score;
    List<GameObject> asteroids;

    // Use this for initialization
    void Start() {
        restart = false;
        gameOver = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnAsteroids());

        asteroids = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < PooledAsteroids; i++) {
            obj = (GameObject)Instantiate(Asteroids);
            obj.name = "AstroideCool " + i;
            obj.SetActive(false);
            asteroids.Add(obj);
        }
    }

    private void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                Debug.Log("Fin");
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnAsteroids() {
        yield return new WaitForSeconds(StartWait);
        while (true) {
            for (int i = 0; i < asteroids.Count; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                if (!asteroids[i].activeInHierarchy) {
                    asteroids[i].transform.position = spawnPosition;
                    asteroids[i].transform.rotation = spawnRotation;
                    asteroids[i].SetActive(true);
                }
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);

            if (gameOver) {
                RestartText.text = "Press R to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        ScoreText.text = "Score: " + score;
    }

    public void GameOver() {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }
}
