using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBall : MonoBehaviour
{
    public float speed = 5.0f; 
    public float lifeTime = 5.0f; 
    public Transform target;


    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        if (target != null)
        {
            Vector3 direcao = (target.position - transform.position).normalized;


            transform.Translate(direcao * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
