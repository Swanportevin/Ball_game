using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallGlitching : MonoBehaviour
{
    public Vector3 contactpoint;
    private PlayerController PlayerController_script;

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
        if (player.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = player.GetContact(0);
            contactpoint = contact.point;
            if (contactpoint.z > 3.9 && transform.position.z>18 && transform.position.z<31)
            {
                Debug.Log(contactpoint + "Added left force");
                PlayerController_script.rigidBody.AddForce(Vector3.left * 20 * contactpoint.z);
            }
        }
}
private void OnCollisionExit(Collision player)
{
    if (player.gameObject.CompareTag("Player")){
            Vector3 currentVelocity = PlayerController_script.rigidBody.velocity;
            PlayerController_script.rigidBody.velocity = new Vector3(currentVelocity.x/2, currentVelocity.y, 0);
    }

}
}
