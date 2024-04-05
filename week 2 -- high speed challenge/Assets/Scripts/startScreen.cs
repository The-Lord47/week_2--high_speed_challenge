using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class startScreen : MonoBehaviour
{
    bool startGame = false;
    public TMP_Text startScreen_txt;
    public GameObject panel;
    public GameObject panel2;
    bool breakOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (breakOut == false)
        {
            if (Input.GetKeyUp(KeyCode.Space) == true)
            {
                startGame = true;
            }
            if (startGame == false)
            {
                Time.timeScale = 0f;
            }
            if (startGame == true)
            {
                startScreen_txt.enabled = false;
                panel.SetActive(false);
                panel2.SetActive(false);
                Time.timeScale = 1f;
                breakOut = true;
            }
        }
        
    }
}
