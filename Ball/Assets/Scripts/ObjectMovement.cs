using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Collider objectCollider;
    private GameManager GameManager_script;
    private Vector3 MovingDirection = Vector3.forward;
    private int leftBorder = -10;
    private int rightBorder = 10;


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
        // Bewegung der moving enemies.
        if (gameObject.CompareTag("MovingEnemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * GameManager_script.speed);
            transform.Translate(MovingDirection * Time.deltaTime * (GameManager_script.speed - 30));
            if (transform.position.x < leftBorder)
            {
                MovingDirection = Vector3.forward;
            }
            if (transform.position.x > rightBorder)
            {
                MovingDirection = Vector3.back;
            }
        }
        //move dollar forward
        if (gameObject.CompareTag("Dollar"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed, Space.World);
        }

    }

}
