using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    Rigidbody ourRigidBody;
    
    float speed = 4;
    float turnSpeed = 90;

    bool allowJump = true;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown(KeyCode.Space)&&allowJump)    
        {
            //ourRigidBody.AddExplosionForce(500, transform.position + Vector3.down, 2);
            ourRigidBody.AddForce(400*Vector3.up);
            allowJump = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            allowJump = true;
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(500*transform.position);
        }
    }
}

