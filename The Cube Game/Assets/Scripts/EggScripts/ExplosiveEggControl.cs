using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEggControl : MonoBehaviour
{
    Vector3 destination;
    int possibleRange = 10;

    Rigidbody eggRigidBody;

    void Start()
    {
        eggRigidBody = GetComponent<Rigidbody>();
        float randomX = Random.Range(transform.position.x - possibleRange, transform.position.x + possibleRange);
        float randomZ = Random.Range(transform.position.z - possibleRange, transform.position.z + possibleRange);
        destination = new Vector3(randomX, transform.position.y+1, randomZ);
        print(randomX + " " + randomZ);
        Explode();
        
    }

    void Update()
    {
     
    }

    void Explode()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination, 1000 * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(1,1,1), 1000 * Time.deltaTime);
        eggRigidBody.AddExplosionForce(500, transform.position + Vector3.down, 2);
    }
}