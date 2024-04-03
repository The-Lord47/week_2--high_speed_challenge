using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    //a public transform that references the player
    public Transform player;
    //a simple bool that can toggle the camera between third and first person
    private bool cameraToggle = true;
    //the offset for the third person camera
    private Vector3 TP_offset = new Vector3(0, 8, -9);
    //the offset for the first person camera
    private Vector3 FP_offset = new Vector3(0, 2.5f, 4);
    //a vector that will store the third person camera's current rotation
    private Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the third person camera's current rotation
        currentRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        //if the V key is pressed down, the code inside will run
        if (Input.GetKeyDown(KeyCode.V) == true)
        {
            //toggles the camera toggle bool
            cameraToggle = !cameraToggle;
            //reverses the angle of current rotation
            //currentRotation *= -1;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            //changes the current rotation of the camera by the inverse of what it was to make the camera look "straight ahead"
            transform.Rotate(currentRotation);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if the camera is toggled to third person, the code inside will run
        if (cameraToggle == true)
        {
            //moves the camera to the third person view
            transform.position = player.transform.position + TP_offset;
        }
        //otherwise, the code inside here runs
        else
        {
            //moves the camera to the first person view
            transform.position = player.transform.position + FP_offset;
            //new
            transform.rotation = player.transform.rotation;
        }
    }

}
