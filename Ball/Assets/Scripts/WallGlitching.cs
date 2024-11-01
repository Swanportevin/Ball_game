using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallGlitching : MonoBehaviour
{
    public Vector3 contactpoint;
    private PlayerController PlayerController_script;
    public bool isWallglitching;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController_script = GameObject.Find("Player").GetComponent<PlayerController>();
    }

private void OnCollisionEnter(Collision player){
    if (player.gameObject.CompareTag("Player"))
    {
        // Calculating the contact point between the ball and the floor.
        ContactPoint contact = player.GetContact(0);
        contactpoint = contact.point;
        // Checking if the z contact point isn't above 3.9, that the z location of the prefab is 18<z<31 and that the ball is on the right.
        if (contactpoint.z > 3.9 && transform.position.z > 18 && transform.position.z < 31 && PlayerController_script.transform.position.x > 0)
        {
            // Reduce the x velocity when entering the glitching wall.
            Vector3 currentVelocity = PlayerController_script.rigidBody.velocity;
            PlayerController_script.rigidBody.velocity = new Vector3(currentVelocity.x/3, currentVelocity.y, 0);
        }
    }


    }
private void OnCollisionStay(Collision player){
        // If the player starts to go trough the wall, add a left force.
        if (player.gameObject.CompareTag("Player"))
        {
            // Calculating the contact point between the ball and the floor.
            ContactPoint contact = player.GetContact(0);
            contactpoint = contact.point;
            // Checking if the z contact point isn't above 3.9, that the z location of the prefab is 18<z<31 and that the ball is on the right.
            if (contactpoint.z > 3.9 && transform.position.z>18 && transform.position.z<31 && PlayerController_script.transform.position.x >0)
            {
                // If the requirements are met: set the bool to true and add left- and up-forces to the ball.
                isWallglitching = true;
                PlayerController_script.rigidBody.AddForce(Vector3.left * 60 * contactpoint.z);
                PlayerController_script.rigidBody.AddForce(Vector3.up * PlayerController_script.speed);
            }
        }
}
private void OnCollisionExit(Collision player)
{
    // If the player exists the wall.
    if (player.gameObject.CompareTag("Player")){
            // Set the bool to false and reduce the x and y velocity.
            isWallglitching = false;
            Vector3 currentVelocity = PlayerController_script.rigidBody.velocity;
            PlayerController_script.rigidBody.velocity = new Vector3(currentVelocity.x/3, currentVelocity.y/2, 0);
    }

}
}
