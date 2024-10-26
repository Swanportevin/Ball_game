using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemy;
    Rigidbody rigidBodyEnemy;
    Rigidbody rigidBodyPlayer;

    private GameManager GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rigidBodyPlayer = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) // Zerst�rt Player und Enemy bei Kollision.
    {
        enemy = other.gameObject;
        
        

    }
}
