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
    public bool isGameActive = true;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private SpawnManager SpawnManager_script;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager_script = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive){
            SpawnManager_script.SpawnPipe();
        }
        
    }

    public void UpdateScore(int ScoreToAdd) {
        if (isGameActive){
            score += ScoreToAdd;
            scoreText.text = "Score:"+(score);
        }
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateSpeed(){
        if (score / 3 <= 3)
        {
            speed += 1;
        }
        
    }
}
