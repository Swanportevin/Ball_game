using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Used to change between menu scene and play scene.

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText2;
    private float highscore; // Contains the highscore to show on the menu screen.

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        highScoreText2.text = "Highscore: " + Math.Round(highscore); // Shows the highscore on the menu screen

        //Gets the gameManager if it exists.
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Restarts the game if space is clicked.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (gameManager == null)
            {
                Play();
            }
            else if (!gameManager.isGameActive)
            {
                ReturnToMenu();
            }
        }
    }

    public void Play() // Function for the play button.
    {
        SceneManager.LoadScene(1);
    }

    public void Quit() // Function for the quit button.
    {
        Application.Quit();
    }

    public void ReturnToMenu() // Function for the menu button.
    {
        SceneManager.LoadScene(0);
    }
}
