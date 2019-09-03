using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] enemyShip;
    [SerializeField] private Vector3 spawn;
    [SerializeField] private float waveWait;
    [SerializeField] private float spawnWait;
    [SerializeField] private float countEnemy;
    [SerializeField] private float countEnemyShip;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text gameOverText;

    private bool restart;
    private bool gameover;
    private int score { get; set; }

    void Start () {
        restart = false;
        gameover = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;

        UpdateScore();
        StartCoroutine( Wave());
	}

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("game", LoadSceneMode.Single);
            }
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    } 

    public void NewScore(int scr)
    {
       score += scr;
       UpdateScore();
    }

    public void GameOver()
    {
        gameover = true;
        gameOverText.text = "Game Over"; 
    }

    IEnumerator Wave()
    {
        while (true)
        {
            for (int i = 0; i < countEnemy; i++)
            {
                if (gameover)
                {
                    restartText.text = "Press 'Q' to restart";
                    restart = true;
                    yield break;
                }
                Vector3 positionSpawn = new Vector3(Random.Range(-spawn.x, spawn.x), spawn.y, spawn.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, positionSpawn, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.3f, spawnWait));
            }

            countEnemy += 5;
            yield return new WaitForSeconds(waveWait);

            for (int i = 0; i < countEnemy; i++)
            {
                if (gameover)
                {
                    restartText.text = "Press 'Q' to restart";
                    restart = true;
                    yield break;
                }
                Vector3 positionSpawn = new Vector3(Random.Range(-spawn.x, spawn.x), spawn.y, spawn.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(enemyShip[Random.Range(0, enemyShip.Length)], positionSpawn, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.3f, spawnWait));
            }
            countEnemyShip += 5;
            yield return new WaitForSeconds(waveWait);
        }

    }
}
