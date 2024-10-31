using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround; // Boolean. True if the ball touches the ground -> Player input is possible.

    public float speed = 5f; // Speed of the ball movement.
    public float gravityModifier = 1.5f; // Variable to optimize gravity physics.

    private GameManager GameManager_script;
    private WallGlitching WallGlitching_script;

    public Vector3 contactpoint;
    public Vector3 OrtogonalVector;

    public ParticleSystem DollarExplosion;
    // All the audiotrack.
    public AudioSource audioSource;
    public AudioClip enemySound;
    public AudioClip dollarSound;
    public AudioClip groundSound;

    public Rigidbody rigidBody; // Player rigidbody.


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); // Get the Rigidbody component.
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Get the game manager script.
 
    }

    void Update()
    {
        
        if (GameObject.Find("halfpipeRiver(Clone)") != null) // Check if the wall glitching prefab exists.
        {
            // Get the WallGlitching script
            WallGlitching_script = GameObject.Find("halfpipeRiver(Clone)").GetComponent<WallGlitching>();
        }
        
        // Steering of the ball.
        if (isOnGround && GameManager_script.isGameActive)
        {
            // Calculating the movement vector, tangent of the contact point on the pipe.
            OrtogonalVector = Vector3.Cross((contactpoint - transform.position), new Vector3(0, 0, 1)).normalized;
            // Desable turning right if the ball is glithing through the wall.
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !WallGlitching_script.isWallglitching) 
                {
                    // Add force to the right.
                    rigidBody.AddForce(-OrtogonalVector * speed);

                }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Add force to the left.
                rigidBody.AddForce(OrtogonalVector * speed);
            }

        }
        
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(Physics.gravity * gravityModifier, ForceMode.Acceleration); // Modifies gravity.

    }


    // The following check for ground contact / no ground contact of the ball and for collisions with enemies and dollars.

    private void OnCollisionEnter(Collision other)
    {
        if (GameManager_script.isGameActive)
        {

            if (other.gameObject.CompareTag("Dollar"))// Add +5 to score, play animation and destroy dollar.
            {
                audioSource.Stop();
                audioSource.PlayOneShot(dollarSound);
                GameManager_script.DollarScore += 5;
                DollarExplosion.Play();
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Ground"))// Enable movement and loop music.
            {
                isOnGround = true;
                audioSource.clip = groundSound;
                audioSource.loop = true;           
                audioSource.Play(); 
            }
            if (other.gameObject.tag.Contains("Enemy"))// Activate gameOver in the game manager, destroys enemy/moving enemy and player.
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

            // Calculates the contact point for the movement vector.
            ContactPoint contact = ground.GetContact(0);
            contactpoint = contact.point;
            
            if (!audioSource.isPlaying)// Loop the ball rolling audio.
            {
                audioSource.clip = groundSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Checks if the object stops touching the ground.
        if (collision.gameObject.CompareTag("Ground") && GameManager_script.isGameActive)
        {
            isOnGround = false;
            audioSource.Stop();//Stops the ball rolling audio.
            // Deletes the x velocity to keep the ball in the pipe.
            if (transform.position.y>7 && transform.position.y<11)// Only for the left- and right side of the pipe(Enable looping).
            {
                // Only keep the upwards velocity to land in the.
                Vector3 currentVelocity = rigidBody.velocity;
                rigidBody.velocity = new Vector3(0, currentVelocity.y, 0);
            }
        }
    }
    

}

