using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float behindBound;
    private float downBound;
    private Collider objectCollider;
    public Vector3 objectSize;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        objectSize = renderer.bounds.size; // Berechnung der Grösse der Halfpipe.
        behindBound = -23f - objectSize.z/2; // -23 ist z Position der Main Camera.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z < behindBound) // Zerstört Halfpipe, wenn behindBound unterschritten wird.
        {
            Destroy(gameObject);
        }
        if (transform.position.y < downBound)
        {
            Destroy(gameObject);
        }
    }
}
