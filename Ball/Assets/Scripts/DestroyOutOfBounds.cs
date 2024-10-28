using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float behindBound = -50.0f; // Point behind the camera at which the objects get destroyed.
    private float BottomLimit = -20.0f; // Point under the halfpipes at which falling objects get destroyed.

    private GameManager GameManager_script;

    public AudioSource audioSource;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {

        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < behindBound) // Deletes objects behind the camera.
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
