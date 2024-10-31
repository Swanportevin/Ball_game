using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{

    private float spinSpeed = -250;

    void Update()
    {
        // Rotates the ball in the menu around it's own y-axis.
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime); 
    }
}
