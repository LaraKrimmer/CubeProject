using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{

    float speed = 4;
    float turnSpeed = 45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            if (Input.GetKey(KeyCode.LeftShift))
                transform.position += transform.forward * Time.deltaTime * (speed*2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.Q))
            transform.position -= transform.right * Time.deltaTime * (speed/2);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
            transform.position += transform.right * Time.deltaTime * (speed/2);

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * (speed/2);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up, 180);
            }
        }

    }
}

