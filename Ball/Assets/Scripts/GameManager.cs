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
    public float score;
    private float time = 0.0f;
    public int DollarScore = 0; // Variable to add the points from collected dollars to the current score.
    private int halfpipeCounter;

    public TextMeshProUGUI scoreText; // Display during game is active.
    public TextMeshProUGUI highScoreText; // Display during game is active.
    public TextMeshProUGUI EndScoreText; // Display after game over.
    public TextMeshProUGUI EndHighScoreText; // Display after game over.
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI PlayAgainText;
    public Button menuButton;

    private SpawnManager SpawnManager_script;

    void Start()
    {
        PlayerPrefs.SetFloat("highscore", highscore); // Set the highscore in the playerprefs to save it.
        SpawnManager_script = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        time = 0;
        highscore = PlayerPrefs.GetFloat ("highscore", highscore); // Saves the highscore and keeps it for every new session.
    }

    void Update()
    {
        time += Time.deltaTime; // Calculate the time.
        if (isGameActive)
        {
            SpawnManager_script.SpawnPipe();//Spawns the halfpipes.

            // Calculates the score and shows it.
            score = time + DollarScore;
            scoreText.text = "Score: " + Math.Round(score); // Show integer
            highScoreText.text = "Highscore: " + Math.Round(highscore); // Show integer
            if (Math.Round(score) > highscore)
            {
                // Sets new highscore.
                highscore = score;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            // Speed converges against 120.
            speed = 40 + (80 * time * time - time) / (time * time + 9000);

        }
        //Blinking Play Again text if the game is over.
        else { 
            if(Math.Round(time*2)%2 == 1)
            {
                PlayAgainText.gameObject.SetActive(true);
            }
            else{
                PlayAgainText.gameObject.SetActive(false);
            }
        }
    }


    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);// Shows the gameover text.
        menuButton.gameObject.SetActive(true);// Shows the menu button.
        EndHighScoreText.text = "Highscore: "+Math.Round(highscore); 
        EndScoreText.text = ""+Math.Round(score); 
        EndHighScoreText.gameObject.SetActive(true); // Show highscore.
        EndScoreText.gameObject.SetActive(true); // Show score.

        // Hide the first score and highscore text
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

        isGameActive = false;

        // Destroys all enemy- and dollar prefabs.
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
