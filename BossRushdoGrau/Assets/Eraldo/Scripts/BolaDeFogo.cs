using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    public float velocidade = 5.0f; 
    public float tempoDeVida = 5.0f; 
    public Transform alvo;

    private void Awake()
    {
        
    }
    private void Start()
    {
        Destroy(gameObject, tempoDeVida); 
    }

    private void Update()
    {
        if (alvo != null)
        {
            Vector3 direcao = (alvo.position - transform.position).normalized;


            transform.Translate(direcao * velocidade * Time.deltaTime);
        }
    }
}







