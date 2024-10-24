using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool isOnGround = true;
    public float gravityModifier = 1.5f;
    private GameManager GameManager_script;
    public Vector3 contactpoint;
    public Vector3 OrtogonalVector;

    Rigidbody rigidBody;

    // Start is called before the first frame update



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Contact Point: " + contactpoint);
        
        // Steuerung
        if (isOnGround)
        {
            OrtogonalVector = Vector3.Cross((contactpoint - transform.position), new Vector3(0, 0, 1)).normalized;
            if (transform.position.y < 7)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rigidBody.AddForce(Vector3.right * speed);

                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rigidBody.AddForce(Vector3.left * speed);
                }
            }
            if (transform.position.y > 7)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rigidBody.AddForce(-OrtogonalVector * speed/3);

                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rigidBody.AddForce(OrtogonalVector * speed/3);
                }
            }

        }
        
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(Physics.gravity * gravityModifier, ForceMode.Acceleration);

    }


    // folgende erm�glichen die Bewegung der Kugel nur bei Bodenkontakt.

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Dollar")){
            GameManager_script.UpdateScore(5);
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionStay(Collision ground)
    {

        if (ground.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            ContactPoint contact = ground.GetContact(0);
            contactpoint = contact.point;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object stops touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            // deleting the x velocity to keep the ball in the pipe
            if (transform.position.y>7 && transform.position.y<11)
            {
                Vector3 currentVelocity = rigidBody.velocity;
                rigidBody.velocity = new Vector3(0, currentVelocity.y, 0);
            }
            
        }
    }
    

}

