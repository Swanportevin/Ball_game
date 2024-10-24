using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float behindBound = -50.0f;
    private float BottomLimit = -20.0f;
    private GameManager GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < behindBound) // Zerst�rt Halfpipe, wenn behindBound unterschritten wird.
        {
            Destroy(gameObject);
            GameManager_script.UpdateSpeed();

        }


        if (gameObject.CompareTag("Player") && transform.position.y < BottomLimit)
        {
            GameManager_script.GameOver();
            Destroy(gameObject);
        }
        else if (transform.position.y < BottomLimit)
        {
            Destroy(gameObject);
        }
    }
        
}
