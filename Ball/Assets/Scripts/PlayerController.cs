using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool isOnGround;
    public float gravityModifier = 1.5f;
    private GameManager GameManager_script;
    public Vector3 contactpoint;
    public Vector3 OrtogonalVector;
    public ParticleSystem DollarExplosion;
    public AudioSource audioSource;
    public AudioClip enemySound;
    public AudioClip dollarSound;
    public AudioClip groundSound;



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
        if (isOnGround && GameManager_script.isGameActive)
        {
            //Calculating the movement vector
            OrtogonalVector = Vector3.Cross((contactpoint - transform.position), new Vector3(0, 0, 1)).normalized;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    rigidBody.AddForce(-OrtogonalVector * speed);//Vector3.right

                }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody.AddForce(OrtogonalVector * speed);//Vector3.left
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
        if (GameManager_script.isGameActive)
        {

            if (other.gameObject.CompareTag("Dollar"))//+5 Score, play animation and destroy gameobject
            {
                audioSource.Stop();
                audioSource.PlayOneShot(dollarSound);
                GameManager_script.DollarScore += 5;
                DollarExplosion.Play();
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Ground"))//Enable movement and loop music
            {
                isOnGround = true;
                audioSource.clip = groundSound;
                audioSource.loop = true;           
                audioSource.Play(); 
            }
            if (other.gameObject.CompareTag("Enemy"))//GameOver in gamemanager and destroy game Object
            {
                audioSource.Stop();
                audioSource.PlayOneShot(enemySound);
                GameManager_script.GameOver();
                Destroy(other.gameObject);
                Destroy(gameObject);

            }
            if (other.gameObject.CompareTag("MovingEnemy"))//GameOver in gamemanager and destroy game Object
            {
                audioSource.Stop();
                audioSource.PlayOneShot(enemySound);
                GameManager_script.GameOver();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision ground)
    {
        
        if (ground.gameObject.CompareTag("Ground") && GameManager_script.isGameActive)
        {
            isOnGround = true;
            //calculate contact point
            ContactPoint contact = ground.GetContact(0);
            contactpoint = contact.point;
            if (!audioSource.isPlaying)//Loop the audio
            {
                audioSource.clip = groundSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object stops touching the ground
        if (collision.gameObject.CompareTag("Ground") && GameManager_script.isGameActive)
        {
            isOnGround = false;
            audioSource.Stop();//Stop the ball rolling audio
            // deleting the x velocity to keep the ball in the pipe
            if (transform.position.y>7 && transform.position.y<11)//Enable the looping
            {
                //ball lands in the pipe
                Vector3 currentVelocity = rigidBody.velocity;
                rigidBody.velocity = new Vector3(0, currentVelocity.y, 0);
            }
        }
    }
    

}

