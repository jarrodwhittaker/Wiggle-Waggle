using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWiggle : MonoBehaviour {

    public float baseSpeed;
    public float lastRotation;
    public float currentRotation;
    public bool Trigger = false;
    public float topSpeed = 2000;
    public float constantSpeed = 1500;

    Vector3 mousePos;
    Vector3 currentMousePos;

    // Use this for initialization
    void Start () {
        mousePos = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {
        //Grab the current rotation
        currentRotation = transform.localRotation.y;

        currentMousePos = Input.mousePosition;

        baseSpeed = Input.GetAxis("Mouse X") / Time.deltaTime + arduino.gx1 * 0.01f;

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
        if (baseSpeed >= topSpeed)
        {
            
        }

    }
}
