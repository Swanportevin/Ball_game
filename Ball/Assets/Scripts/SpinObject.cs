using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarRotation : MonoBehaviour
{

    private float spinSpeed = -250;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
