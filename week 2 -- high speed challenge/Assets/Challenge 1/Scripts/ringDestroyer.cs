using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringDestroyer : MonoBehaviour
{
    GameObject ringCollect;
    // Start is called before the first frame update
    void Start()
    {
        //finds the ring collect soundeffect gameobject
        ringCollect = GameObject.FindGameObjectWithTag("Collect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        //once the player leaves a ring, it will deactivate itself and play the ring collection sound effect
        if (other.tag == "Player")
        {
            transform.parent.gameObject.SetActive(false);
            ringCollect.GetComponent<AudioSource>().Play();
        }
    }
}
