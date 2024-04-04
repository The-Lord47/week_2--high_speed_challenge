using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueLight : MonoBehaviour
{
    public Light myLight;
    public float interval = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        myLight.enabled = !myLight.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            timer -= interval;
        }
    }
}
