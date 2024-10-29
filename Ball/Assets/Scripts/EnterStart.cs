using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Used to change between menu scene and play scene.

public class EnterStart : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //Get gameManager if it exists
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //Restart the game if space is clicked
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (gameManager == null)
            {
                SceneManager.LoadScene(1);

            }
            else if (!gameManager.isGameActive)
            {
                SceneManager.LoadScene(0);
            }
    }
}
}
