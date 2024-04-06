using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    float verticalInput;
    float scoreCounter;
    public TMP_Text scoreCounter_txt;
    public GameObject scoreCounter_obj;
    bool isFinished = false;
    public float descentSpeed;
    bool ontheGround = false;
    Rigidbody plane;
    public GameObject propeller;
    public GameObject playerCamera;
    public TMP_Text endScreen_txt;
    public GameObject panel;
    public GameObject endScreen;
    public GameObject propNoise;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the rigidbody of the plane
        plane = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //runs if the player has not finished the game yet
        if (isFinished == false)
        {
            // get the user's vertical input
            verticalInput = Input.GetAxis("Vertical1");

            // move the plane forward at a constant rate
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);
        }
        //runs if the player has finished the game
        if (isFinished == true)
        {
            //slows the plane down as time passes
            speed -= Time.deltaTime;
            //moves the plane forward if the speed is greater than 0
            if (speed > 0)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            //descends the plane if it is off the ground
            if (ontheGround == false)
            {
                transform.Translate(Vector3.up * -1 * descentSpeed * Time.deltaTime);
            }
            //stops the propeller from rotating and making noise if the plane's speed is less than 2
            if (speed < 2)
            {
                propeller.GetComponent<propellerRotation>().rotationSpeed = new Vector3(0, 0, 0);
                propNoise.GetComponent<AudioSource>().Stop();
            }
            //once the plane has stopped, activates the end screen and allows the game to restart
            if (speed < 0)
            {
                panel.SetActive(true);
                endScreen.SetActive(true);
                scoreCounter_obj.SetActive(false);
                endScreen_txt.text = "Congratulations! \n You have landed the plane with a score of " + scoreCounter + "\n \n Press 'Space' to start again!";
                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
       

        //updates the score counter
        scoreCounter_txt.text = "Score: " + scoreCounter;
    }

    private void OnTriggerExit(Collider other)
    {
        //increases the score counter when leaving the ring collider
        if (other.tag == "Ring")
        {
            scoreCounter++;
        }
        //increases the score collider when leaving the finish ring and also sets the plane up for automatic descent.
        if (other.tag == "Finish")
        {
            scoreCounter++;
            isFinished = true;
            transform.position = new Vector3(0f, -5.5f, 208f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            plane.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //detects if the plane has touched the ground when landing and repositions the camera for a better view
        if (other.tag == "Ground" && isFinished == true)
        {
            ontheGround = true;
            playerCamera.GetComponent<FollowPlayerX>().offset = new Vector3(25,5,5);
        }
    }


}
