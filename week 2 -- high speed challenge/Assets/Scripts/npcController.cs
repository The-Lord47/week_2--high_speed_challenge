using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody car;
    Vector3 relativeForwards;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        relativeForwards = transform.InverseTransformDirection(Vector3.forward);
        transform.Translate(moveSpeed * -1 *relativeForwards * Time.deltaTime);
    }
}
