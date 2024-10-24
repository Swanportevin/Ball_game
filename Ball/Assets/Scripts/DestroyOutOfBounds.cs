using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public GameObject Player;
    private float behindBound;
    private float BottomLimit = -20;
    private Collider objectCollider;
    public Vector3 objectSize;
    private GameManager GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        objectSize = renderer.bounds.size; // Berechnung der Gr�sse der Halfpipe.
        behindBound = -23f - objectSize.z/2; // -23 ist z Position der Main Camera.
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

        if (GameManager_script.isGameActive)
        {

            if (Player.transform.position.y < BottomLimit)
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
}
