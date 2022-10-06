using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public int MHP = 100;
    int CHP;

    public Material normalMat;
    public Material deathMat;

    MeshRenderer ourRenderer;

    void Start()
    {
        ourRenderer = GetComponent<MeshRenderer>();
        CHP = MHP;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ChangeHP(-12);
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            ChangeHP(12);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ChangeHP(MHP);
        }
    }

    internal void ChangeHP (int amount)
    {
        if (amount >= MHP - CHP)
        {
            CHP = MHP;
            print("Health is now " + CHP);
            ourRenderer.material = normalMat;

        }
        else if (CHP + amount <= 0)
        {
            CHP = 0;
            print("Death");
            ourRenderer.material = deathMat;
        }
        else
        {
            CHP += amount;
            print("Health is now " + CHP);
        }

    }

    internal int whatsYourMaxHealth()
    {
        return MHP;
    }
}
