using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public int speed = 40;
    public static float highscore;
    public bool isGameActive = true;
    private float time = 0.0f;
    private float timeAsScore;
    private int halfpipeCounter;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;
    public Button menuButton;
    private SpawnManager SpawnManager_script;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager_script = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        time = 0;
        highscore = PlayerPrefs.GetFloat ("highscore", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            SpawnManager_script.SpawnPipe();
            UpdateScore(0);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        time += Time.deltaTime + ScoreToAdd;
        timeAsScore = Mathf.Round(time);
        scoreText.text = "Score: " + timeAsScore;
        highScoreText.text = "Highscore: " + highscore;
        if (timeAsScore > highscore)
        {
            highscore = timeAsScore;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        //scoreText.rectTransform.position = new Vector3(-102, -300);
        //highScoreText.rectTransform.position = new Vector3(-102, -285);

        isGameActive = false;
    }

    public void UpdateSpeed()
    {
        halfpipeCounter++;

        if (halfpipeCounter == 3)
        {
            speed++;
            halfpipeCounter = 0;
        }

    }
}
