using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Collider objectCollider;
    public Vector3 objectSize;



    // Start is called before the first frame update
    void Start()
    {

        //Berechnung der jeweiligen L�nge der Halfpipes.
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        objectSize = renderer.bounds.size;
        

    }

    // Update is called once per frame
    void Update()
    {
        //Bewegung der Halfpipes.
        if (gameObject.CompareTag("Ground"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed);
        }
        // Bewegung der Enemies.
        if (gameObject.CompareTag("Enemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * GameManager_script.speed);
        }
        
    }

}
