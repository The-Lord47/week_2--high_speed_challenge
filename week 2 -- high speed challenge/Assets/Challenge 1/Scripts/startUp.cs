using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUp : MonoBehaviour
{
    public GameObject startText;
    public GameObject panel;
    public GameObject scoreCounter;
    bool startGame = false;
    bool breakOut = false;

    // Start is called before the first frame update
    void Start()
    {
        //deactivates the score counter on startup
        scoreCounter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //stops the code inside from running when the startup screen is no longer needed
        if (breakOut == false)
        {
            //starts the game by pressing space
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                startGame = true;
            }
            //keeps the game frozen so long as the start screen is active
            if (startGame == false)
            {
                Time.timeScale = 0f;
            }
            //begins the game and gets rid of the start screen
            if (startGame == true)
            {
                startText.SetActive(false);
                panel.SetActive(false);
                scoreCounter.SetActive(true);
                Time.timeScale = 1f;
                breakOut = true;
            }
        }
        

    }
}
