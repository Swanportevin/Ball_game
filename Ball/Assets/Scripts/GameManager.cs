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
    public bool isGameActive = true;

    public float speed = 40.0f;
    public static float highscore;
    private float time = 0.0f;
    public int DollarScore = 0; // Variable to add the points from collected dollars to the current score.
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
        highscore = PlayerPrefs.GetFloat ("highscore", highscore); // Saves the highscore and keeps it for every new session.
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            SpawnManager_script.SpawnPipe();//Spawns the halfpipes.

            // Calculates the score and shows it.
            time += Time.deltaTime;
            scoreText.text = "Score: " + Math.Round(time+DollarScore);
            highScoreText.text = "Highscore: " + Math.Round(highscore);
            if (Math.Round(time+DollarScore) > highscore)
            {
                // Sets new highscore.
                highscore = time+DollarScore;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            // Speed converges against 120.
            speed = 40 + (80*time*time-time)/(time*time+9000);
            
        }
    }


    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);// Shows the gameover text.
        menuButton.gameObject.SetActive(true);// Shows the menu button.

        // Moves the score and highscore under the menu button.
        scoreText.rectTransform.position = new Vector2(855, 220);
        highScoreText.rectTransform.position = new Vector2(855, 300);

        isGameActive = false;

        // Destroys all enemies and Dollars.
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
