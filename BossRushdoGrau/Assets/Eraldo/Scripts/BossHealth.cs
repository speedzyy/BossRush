using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    int vidaAtual;
    int vidaMaxima;

    void Update()
    {
        
    }

    void Damage(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morre();
        }


    }

    private void Morre()
    {
       Destroy(gameObject);
    }
}

