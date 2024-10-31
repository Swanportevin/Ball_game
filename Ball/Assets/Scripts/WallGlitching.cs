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

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnCollisionStay(Collision player){
        //If the player starts to go trough the wall, add a left force
        if (player.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = player.GetContact(0);
            contactpoint = contact.point;
            Debug.Log(PlayerController_script.transform.position.magnitude);
            if (contactpoint.z > 3.9 && transform.position.z>18 && transform.position.z<31 && PlayerController_script.transform.position.x >0)
            {
                isWallglitching = true;
                Debug.Log( "Added left force");
                PlayerController_script.rigidBody.AddForce(Vector3.left * 60 * contactpoint.z);
                PlayerController_script.rigidBody.AddForce(Vector3.up * PlayerController_script.speed);
            }
        }
}
private void OnCollisionExit(Collision player)
{
    //Remove half of the left force when the player exits the wall
    if (player.gameObject.CompareTag("Player")){
            isWallglitching = false;
            Vector3 currentVelocity = PlayerController_script.rigidBody.velocity;
            PlayerController_script.rigidBody.velocity = new Vector3(currentVelocity.x/3, currentVelocity.y/2, 0);
    }

}
}
