using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpin : MonoBehaviour
{
    public float sensitivity;
    public bool UseX;
    public bool UseY;
    public bool invertX;
    public bool invertY;

    Vector3 lastFramePos;

    // Start is called before the first frame update
    void Start()
    {
        lastFramePos = Input.mousePosition;

        if(!(UseX ^ UseY))
        {
            Debug.LogError("MouseSpin: Either both, or neither input axis was defined.\n");
        }
    }

    float delta_X;
    float delta_Y;

    // Update is called once per frame
    void Update()
    { 
        if ((UseX ^ UseY) && UseX)
        {
            //Represents the change in pixel coordinates of the mouse X and Y position.
            delta_X = Input.mousePosition.x - lastFramePos.x;
            if (invertX) delta_X *= -1.0f;

            //Normalize to the size of the screen
            delta_X = delta_X / Screen.currentResolution.width;

            //Scale the adjustment based on the sensitivity
            delta_X *= sensitivity;

            //Rotate the object around the Y axis by the change in mouse X coordinates
            this.transform.Rotate(0, delta_X, 0);
        }
        else if((UseX ^ UseY) && UseY)
        {
            //Represents the change in pixel coordinates of the mouse X and Y position.
            delta_Y = Input.mousePosition.y - lastFramePos.y;
            if (invertY) delta_Y *= -1.0f;

            //Normalize to the size of the screen
            delta_Y = delta_Y / Screen.currentResolution.height;

            //Scale the adjustment based on the sensitivity
            delta_Y *= sensitivity;

            //Rotate the object around the Y axis by the change in mouse Y coordinates
            this.transform.Rotate(0, delta_Y, 0);
        }

        lastFramePos = Input.mousePosition;
    }
}
