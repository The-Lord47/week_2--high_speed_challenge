using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
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
        transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
    }
}
