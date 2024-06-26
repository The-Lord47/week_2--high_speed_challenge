using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    //create variables necessary for control later in the script

    //controls the car's acceleration
    public float moveSpeed = 10f;
    //connects the rigidbody of the car to a variable named car
    Rigidbody car;
    //a bool to detect if the car is on the ground
    bool onGround = false;
    //a float that is connected to the vertical input axis
    private float acceleration;
    //a float that is connected to the horizontal input axis
    private float turning;
    //a float that controls the turn rate of the car
    public float turnRate;
    //a vector that will hold the velocity of the car in its frame of reference
    private Vector3 relativeVelocity;
    //sets a top speed
    public float topSpeed;
    //connects to the ui that displays the vehicles current speed
    public TMP_Text currentSpeed_txt;
    public TMP_Text endScreen_txt;
    public GameObject restartText_txt;
    public GameObject uiBackground;

    bool gameFreeze = false;

    public string playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gameFreeze == true)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //sets the acceleration depending on the vertical input
        acceleration = Input.GetAxis("Vertical" + playerNumber);
        //sets the turning depending on the vertical input
        turning = Input.GetAxis("Horizontal" + playerNumber);
        //calculates the car's velocity in it's own reference frame
        relativeVelocity = transform.InverseTransformDirection(car.velocity);
        //calculates the car's current speed
        currentSpeed_txt.text = "Current Speed: " + Mathf.Round(relativeVelocity[2] * 2.23f) + " mph";
    }


    private void FixedUpdate()
    {
        //only runs if the car's speed is less than 30m/s (~70mph) and the car is on the ground
        if (relativeVelocity[2] < topSpeed && onGround == true)
        {
            //increases the force applied to the car by its acceleration in the direction of the car's z axis
            car.AddRelativeForce(acceleration * Vector3.forward * moveSpeed);
        }
        //only runs if the car is on the ground and has a positive velocity
        if (onGround == true && relativeVelocity[2] >= -1)
        {
            //turns the car left and right
            //transform.Rotate(Vector3.up, turnRate * turning * Time.deltaTime);
            car.AddRelativeTorque(Vector3.up * turning * turnRate);
        }
        //only runs if the car is on the ground and has a negative velocity
        else if (onGround == true && relativeVelocity[2] < -1)
        {
            //turns the car left and right, but opposite to the above code (this is used when reversing to make it feel like a car)
            //transform.Rotate(Vector3.up, turnRate * -1 *turning * Time.deltaTime);
            car.AddRelativeTorque(Vector3.up * turning * -1 * turnRate);
        }
    }

    //a function that detects when the car is on the ground
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            onGround = true;
        }
        
    }
    //a function that detects when the car leaves the ground
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerNumber == "1" && other.tag == "Finish")
        {
            gameFreeze = true;
            endScreen_txt.text = "Player 1 wins!";
            restartText_txt.SetActive(true);
            uiBackground.SetActive(true);
        }

        if (playerNumber == "2" && other.tag == "Bus")
        {
            gameFreeze = true;
            endScreen_txt.text = "Player 2 wins!";
            restartText_txt.SetActive(true);
            uiBackground.SetActive(true);
        }
    }
}
