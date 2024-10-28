using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    private GameManager GameManager_script;

    private float rotationSpeed; // Speed of the simulated forward rotation of the ball.
    public float rotationMultiplikator; // Variable to change the speed.

    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = rotationMultiplikator * GameManager_script.speed * Time.deltaTime;
        transform.Rotate(Vector3.right, rotationSpeed); // Rotates the ball forward as if it weren't the halfpipes that are moving.
    }
}