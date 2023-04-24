using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    public GameObject Heart; //Object to be rotated around
    

    private Vector3 yAxis = new Vector3(0, 1, 0); //All we need is the Z-Axis of our object

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) //Input for mouse scroll wheel
        {
            transform.transform.RotateAround(Heart.transform.position, -yAxis, 15000 * Time.deltaTime); //Rotates rightwards around heart object
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.RotateAround(Heart.transform.position, yAxis,15000 * Time.deltaTime ); //Rotates leftwards around heart object
        }
        //transform.RotateAround(Heart.transform.position, zAxis, 20 * Time.deltaTime);
    }
}
