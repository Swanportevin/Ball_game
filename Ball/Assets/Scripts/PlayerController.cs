using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isOnGround = true;
    public float gravityModifier = 1.5f;
    private GameManager GameManager_script;

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


    // folgende erm�glichen die Bewegung der Kugel nur bei Bodenkontakt.

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (other.gameObject.CompareTag("dollar")){
            GameManager_script.UpdateScore(5);
            Destroy(other.gameObject);
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

