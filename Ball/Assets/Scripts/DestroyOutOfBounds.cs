using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float behindBound = -70.0f; // Point behind the camera at which the objects get destroyed.
    private float BottomLimit = -20.0f; // Point under the halfpipes at which falling objects get destroyed.

    private GameManager GameManager_script;

    public AudioSource audioSource;
    public AudioClip gameOverSound;

    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Get the game manager script.
    }

    void Update()
    {
        if (transform.position.z < behindBound || transform.position.y<-21) // Deletes objects behind the camera and falling objects.
        {
            Destroy(gameObject);
        }


        if (gameObject.CompareTag("Player") && transform.position.y < BottomLimit)// Activates game over if the player fell from the halfpipes.
        {
            GameManager_script.GameOver();
            audioSource.PlayOneShot(gameOverSound);
            Destroy(gameObject);
        }
        
    }
        
}
