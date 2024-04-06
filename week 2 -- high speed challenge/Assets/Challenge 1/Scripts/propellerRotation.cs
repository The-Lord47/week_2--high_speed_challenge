using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerRotation : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotates the propeller
        transform.Rotate(rotationSpeed);
    }
}
