using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isOnGround = true;
    public float gravityModifier = 1.5f;

    Rigidbody rigidBody;

    // Start is called before the first frame update



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
 
    }

    // Update is called once per frame
    void Update()
    {

        // Steuerung
        if (Input.GetKey(KeyCode.D) && isOnGround)
        {
            rigidBody.AddForce(Vector3.right * speed);
        }
        else if (Input.GetKey(KeyCode.A) && isOnGround)
        {
            rigidBody.AddForce(Vector3.left * speed);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(Physics.gravity * gravityModifier, ForceMode.Acceleration);

    }


    // folgende ermöglichen die Bewegung der Kugel nur bei Bodenkontakt.

    private void OnCollisionEnter(Collision ground)
    {

        if (ground.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }

    private void OnCollisionStay(Collision ground)
    {

        if (ground.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object stops touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    

}

