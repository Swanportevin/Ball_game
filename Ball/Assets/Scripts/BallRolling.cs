using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    private GameManager GameManager_script;
    private float rotationSpeed;
    public float rotationMultiplikator;
    // Start is called before the first frame update
    void Start()
    {
        //Find game Manager Script
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = rotationMultiplikator * GameManager_script.speed * Time.deltaTime;
        transform.Rotate(Vector3.right, rotationSpeed);
    }
}