using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wiggle : MonoBehaviour
{


    public float baseSpeed;
    public float lastRotation;
    public float currentRotation;
    public bool Trigger = false;

    Vector3 mousePos;
    Vector3 currentMousePos;


    // Use this for initialization
    void Start ()
    {
        mousePos = Input.mousePosition;

	}
	
	// Update is called once per frame
	void Update () {
        //Grab the current rotation
        currentRotation = transform.localRotation.y;

        currentMousePos = Input.mousePosition;

        baseSpeed = Input.GetAxis("Mouse X") / Time.deltaTime + arduino.gx1 * 0.01f;
        //Rotate the cylinder right when the right arrow is pressed

        //If the button is pressed...
        /*if (Input.GetButton("RotateRight"))
        {
            
            //rotate the cylinder by baseSpeed by Time.deltaTime in the direction of Vector3.up
            transform.Rotate((Vector3.up * baseSpeed) * Time.deltaTime);
        }
        if (Input.GetButton("RotateLeft"))
        {

            transform.Rotate((Vector3.down * baseSpeed) * Time.deltaTime);
            
        }*/
        if (GameController.Instance.isStart != true)
        {
            if (mousePos.x > currentMousePos.x || arduino.gx1 > 100)
            {

                //rotate the cylinder by baseSpeed by Time.deltaTime in the direction of Vector3.up
                transform.Rotate((Vector3.up * baseSpeed) * Time.deltaTime);
            }
            if (mousePos.x < currentMousePos.x || arduino.gx1 < -100)
            {

                transform.Rotate((Vector3.down * baseSpeed) * Time.deltaTime);

            }
        }


        //Every update needs to check if it's below 0 or above 0
        //Needs to be compared



        // Find the difference between our current rotation and our last rotation.
        // last rotation - current rotation = difference.
        // If it is greater than our base speed we enter our growth state.
        // mathf.abs


        //Debug.Log(currentRotation + " = Current Rotation");
        //Debug.Log(lastRotation + " = Last Rotation");
        //
        if ((Mathf.Abs(currentRotation - lastRotation) > 0))
        {

            // we've travelled far enough to trigger growth.
            // wanting it to grow in size when triggered.
            transform.localScale += new Vector3(0, 0.1f, 0) * 0.5f;
            
        }
        
        
        //Every update creates a last state
        if (currentRotation < 0)
        {
            lastRotation = currentRotation;
        }
        else
        {
            lastRotation = currentRotation;
        }
    }
}
