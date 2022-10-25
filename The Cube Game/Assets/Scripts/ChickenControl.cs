using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenControl : MonoBehaviour
{
    Rigidbody ourRigidBody;
    Animator chickenAnimator;

    public Transform[] eggTemplates = new Transform[4];
    public int currentEggType;

    float speed = 2;
    float turnSpeed = 90;

    bool allowJump = true;

    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody>();
        chickenAnimator = GetComponent<Animator>();
    }

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
            ourRigidBody.AddForce(4000 * Vector3.up);
            allowJump = false;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(eggTemplates[currentEggType], transform.position - (transform.forward) / 2, Quaternion.identity);
            StartCoroutine(EggTimer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            allowJump = true;
        } 
        else if (collision.gameObject.CompareTag("SpeedEgg"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpeedBooster());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            currentEggType = other.GetComponent<BoosterControl>().boosterType;
            Destroy(other.gameObject);
        }
    }

    IEnumerator SpeedBooster()
    {
        float originalSpeed = speed;
        speed *= 2;
        yield return new WaitForSeconds(10);
        speed = originalSpeed;
    }

    IEnumerator EggTimer()
    {
        yield return new WaitForSeconds(10);
        currentEggType = 0;
    }

}
