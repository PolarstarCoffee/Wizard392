using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpin : MonoBehaviour
{
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Mouse ScrollWheel");

        //Rotate the object around the Y axis by the change in mouse X coordinates
        this.transform.Rotate(0, movement * sensitivity, 0);
    }
}