using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //moves object forward
        transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
        */

        if (car.velocity[2] < 30)
        {
            car.AddForce(Vector3.forward * moveSpeed, ForceMode.Acceleration);
        }
        
    }
}
