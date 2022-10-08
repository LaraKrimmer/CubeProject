using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenControl : MonoBehaviour
{
    Rigidbody ourRigidBody;
    Animator chickenAnimator;

    float speed = 2;
    float turnSpeed = 90;

    bool allowJump = true;

    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
        chickenAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            chickenAnimator.SetBool("Walk", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += transform.forward * Time.deltaTime * (speed * 2);
                //chickenAnimator.SetBool("Walk", false);
                chickenAnimator.SetBool("Run", true);
            }
            else
                chickenAnimator.SetBool("Run", false);
        }
        else
            chickenAnimator.SetBool("Walk", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
            transform.position -= transform.right * Time.deltaTime * (speed / 2);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
            transform.position += transform.right * Time.deltaTime * (speed / 2);

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * (speed / 2);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up, 180);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && allowJump)
        {
            //ourRigidBody.AddExplosionForce(500, transform.position + Vector3.down, 2);
            ourRigidBody.AddForce(400 * Vector3.up);
            allowJump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            allowJump = true;
        }
    }
}
