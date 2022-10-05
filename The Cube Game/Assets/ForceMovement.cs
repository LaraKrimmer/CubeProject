using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour
{
    Rigidbody ourRigidBody;

    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ourRigidBody.AddForce(transform.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ourRigidBody.AddForce(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ourRigidBody.AddForce(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ourRigidBody.AddExplosionForce(500, transform.position + Vector3.down, 2);
        }
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch");
        collision.transform.position += Vector3.down;
    }
}
