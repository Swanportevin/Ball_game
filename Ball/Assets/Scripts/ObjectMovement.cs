using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Collider objectCollider;
    private GameManager GameManager_script;


    // Start is called before the first frame update
    void Start()
    {

        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();

        

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
        //move dollar forward
        if (gameObject.CompareTag("dollar"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed, Space.World);
        }
        
    }



}
