using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemonController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] float speed;
    [SerializeField] float tempoParaProximoTiro;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] Transform currentPoint;
    [SerializeField] GameObject fireball;
    [SerializeField] Transform fireballSpawn;
    [SerializeField] BossHealth bossHealth;
    [SerializeField] Transform player;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip fire;
    private bool secondPhase;
    private bool canShoot;

    private void Awake()
    {
        fireShooter();
    }

    void fireShooter()
    {
        if (canShoot)
        {
            source.volume = 0.6f;
            source.pitch = 1;
            source.PlayOneShot(fire);
            anim.SetInteger("transition", 1);
            DemonBall novaBola = Instantiate(fireball, transform.position, Quaternion.identity).GetComponent<DemonBall>();
            novaBola.target = player;
            canShoot = false;
            Invoke("CanShootReset", tempoParaProximoTiro); 
        }
    }

    void CanShootReset()
    {
        canShoot = true;
    }
    
    void Update()
    {

        if (bossHealth.vidaAtual <= bossHealth.maxHealth / 2)
        {
            secondPhase = true;
            SecondStage();
        }

        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }

//ABAIXO ESTÁ O CÓDIGO PARA O BOSS VIRAR PARA A DIREÇÃO QUE O JOGADOR ESTIVER EM RELAÇÃO A ELE.            
        Vector2 scale = transform.localScale;

        if (Player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    void SecondStage()
    {
        
    }
}