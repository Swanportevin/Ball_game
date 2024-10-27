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
            SpawnManager_script.SpawnPipe();//Spawn the pipes
            //Calculating score and showing it
            time += Time.deltaTime;
            scoreText.text = "Score: " + Math.Round(time+DollarScore);
            highScoreText.text = "Highscore: " + Math.Round(highscore);
            if (Math.Round(time+DollarScore) > highscore)
            {
                //Setting new highscore
                highscore = time+DollarScore;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            //Speed converges against 120
            speed = 40 + (80*time*time-time)/(time*time+9000);
            
        }
    }


    public void GameOver() {
        gameOverText.gameObject.SetActive(true);//Show gameover text
        menuButton.gameObject.SetActive(true);//Go back to the menu
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        scoreText.rectTransform.position = new Vector2(855, 250);
        highScoreText.rectTransform.position = new Vector2(855, 300);
        isGameActive = false;
        //Destroying all enemies and Dollar
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
