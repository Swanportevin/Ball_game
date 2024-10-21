using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemy;
    private GameManager GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) // Zerst�rt Player und Enemy bei Kollision.
    {
        enemy = other.gameObject;
        if (enemy.CompareTag("Enemy") || enemy.CompareTag("MovingEnemy"))
        {
            GameManager_script.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        

    }
}
