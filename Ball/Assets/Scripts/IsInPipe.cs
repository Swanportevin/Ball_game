using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInPipe : MonoBehaviour
{
    private GameManager GameManager_script;
    private float BottomLimit = -5;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < BottomLimit) {
            GameManager_script.GameOver();
            Destroy(gameObject);
        }
    }
}
