using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float behindBound;
    private float BottomLimit = -10;
    private Collider objectCollider;
    public Vector3 objectSize;
    private GameManager GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
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
            GameManager_script.UpdateScore(1);
            GameManager_script.UpdateSpeed();
            Debug.Log("Add one point");
        }

        if (transform.position.y < BottomLimit) {
            GameManager_script.GameOver();
            Destroy(gameObject);
        }
    }
}
