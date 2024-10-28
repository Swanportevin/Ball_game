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

    private float borderAngle = 75; // Max angle of the pendulum.
    private float pendulumSpeed = 1.5f; // Speed of the pendulum.
    private Rigidbody pendulumRb;
    private int random; // Random start angle for the pendulum.

    private float spinSpeed = -250.0f; // The speed for the rotation of the dollars.

    


    // Start is called before the first frame update
    void Start()
    {

        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();

        random = Random.Range(0, 20); // Random start angle for the pendulum.

    }

    // Update is called once per frame
    void Update()
    {
        // Moves the halfpipes.
        if (gameObject.CompareTag("Ground"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed);
        }
        // moves the ducks.
        if (gameObject.CompareTag("Enemy"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * GameManager_script.speed);
        }
        // Moves the pendulums.
        if (gameObject.CompareTag("MovingEnemy"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed);
            float angle = borderAngle * Mathf.Sin(Time.time + random + pendulumSpeed); // Pendulum movement with sinus wave.
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            
        }
        
        // Moves dollars and rotates it around itself.
        if (gameObject.CompareTag("Dollar"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager_script.speed, Space.World);
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }

}
