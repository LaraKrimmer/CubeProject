using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggControl: MonoBehaviour
{
    int hatchTime = 3;
    public Transform chickenTemplate;

    void Start()
    {
        StartCoroutine(HatchChicken());
    }

    void Update()
    {
        
    }

    public IEnumerator HatchChicken()
    {
        yield return new WaitForSeconds(hatchTime);
        Instantiate(chickenTemplate, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
