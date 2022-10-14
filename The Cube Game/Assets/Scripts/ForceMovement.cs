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
            
        }
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        Health objectHitHealth = collision.gameObject.GetComponent<Health>();
        if (objectHitHealth)
        {
            objectHitHealth.ChangeHP(-20);

            int ObjectsMaxHP = objectHitHealth.whatsYourMaxHealth();
            if(ObjectsMaxHP > 100)
            {
                objectHitHealth.ChangeHP(-100);
            }
        }
        else
        {
            print("Couldn't find Health script in object hit");
        }
    }
}
