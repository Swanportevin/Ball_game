using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    public float speed = 40.0f;
    public static float highscore;
    public bool isGameActive = true;
    private float time = 0.0f;
    public int DollarScore = 0;
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
            time += Time.deltaTime;
            scoreText.text = "Score: " + Math.Round(time+DollarScore);
            highScoreText.text = "Highscore: " + Math.Round(highscore);
            if (Math.Round(time+DollarScore) > highscore)
            {
                highscore = time+DollarScore;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            speed = 40 + (80*time*time-time)/(time*time+9000);
            
        }
    }


    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        scoreText.rectTransform.position = new Vector2(855, 250);
        highScoreText.rectTransform.position = new Vector2(855, 300);
        isGameActive = false;
        string [] NameToDestroy = { "Enemy", "MovingEnemy", "Dollar" };
        foreach (string tag in NameToDestroy)
        {
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }
        }
        
    }

}
