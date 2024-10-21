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
    private float ScoreToSchow = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI gameOverText;
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
        if (isGameActive){
            SpawnManager_script.SpawnPipe();
            time += Time.deltaTime;
            scoreText.text = "Score: "+Mathf.Round(time*100.0f)*0.01f;
            HighScoreText.text = "Highscore: "+Mathf.Round(highscore*100.0f)*0.01f;
            if (time>highscore){
                highscore = time;
                PlayerPrefs.SetFloat ("highscore", highscore);
            }
        }
    }

    public void UpdateScore(int ScoreToAdd) {
        if (isGameActive){
            time = Time.deltaTime;
            ScoreToSchow = time+ScoreToAdd;
            scoreText.text = "Score:"+ScoreToSchow;
        }
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateSpeed(){
        if (time / 3 <= 3)
        {
            speed += 1;
        }
        
    }
}
