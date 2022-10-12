using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterControl : MonoBehaviour
{
    public Material[] boosterTypes = new Material[4];
    public int boosterType;

    MeshRenderer boosterRenderer;

    void Start()
    {
        boosterRenderer = GetComponent<MeshRenderer>();

        boosterType = Random.Range(0, boosterTypes.Length);
        boosterRenderer.material = boosterTypes[boosterType];
    }

    
    void Update()
    {
        
    }

}
