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
    private float borderAngle = 75;
    private Rigidbody pendulumRb;
    private float pendulumSpeed = 1.5f;
    private int random;
    private float spinSpeed = -250.0f;


    // Start is called before the first frame update
    void Start()
    {

        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();

        random = Random.Range(0, 20);

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
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed);
            float angle = borderAngle * Mathf.Sin(Time.time + random + pendulumSpeed);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            
        }
        
        //move dollar forward without affecting his rotation
        if (gameObject.CompareTag("Dollar"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed, Space.World);
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }

}
