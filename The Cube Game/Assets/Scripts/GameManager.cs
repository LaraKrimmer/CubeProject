using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int maxBoosters = 100;
    int minBoosters = 10;

    public Transform boosterTemplate;

    void Start()
    {
        int boosterCount = Random.Range(minBoosters, maxBoosters);
        for(int i = 0; i<=boosterCount; i++)
        {
            float randomX = Random.Range(-70, 70);
            float randomZ = Random.Range(-70, 70);
            Vector3 spawnLocation = new Vector3(randomX, 0.1f, randomZ);

            Instantiate(boosterTemplate, spawnLocation, Quaternion.Euler(-90,0,0));
        }
    }

    void Update()
    {
        
    }
}
