using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText2;
    private float highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        highScoreText2.text = "Highscore: " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        
        SceneManager.LoadScene(0);
        
    }
}
