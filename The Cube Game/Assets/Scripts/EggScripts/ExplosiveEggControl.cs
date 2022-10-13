using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEggControl : MonoBehaviour
{
    Vector3 destination;
    int possibleRange = 100;

    void Start()
    {
        float randomX = Random.Range(transform.position.x - possibleRange, transform.position.x + possibleRange);
        float randomZ = Random.Range(transform.position.z - possibleRange, transform.position.z + possibleRange);
        destination = new Vector3(randomX, transform.position.y, randomZ);
        print(randomX + " " + randomZ);
    }

    void Update()
    {
        Vector3.MoveTowards(transform.position, destination, 1 * Time.deltaTime);
    }
}