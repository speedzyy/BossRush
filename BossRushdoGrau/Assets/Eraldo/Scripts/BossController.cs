using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] Vector2 jumpForceDirection;
    [SerializeField, Min(0)] float raycastDistance;
    [SerializeField] float jumpingInterval;
    float jumpingIntervalAtual;
    public float tempoParaProximoTiro;
    
    [Header("Componentes")]
    [SerializeField] Rigidbody2D rigiBody2D;
    [SerializeField] GameObject bolaDeFogo;
    [SerializeField] Transform spawnDaBola;
    [SerializeField] BossHealth bossHealth;
    [SerializeField] Transform player;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip fire;
    [SerializeField] Animator anim;
    [SerializeField] LayerMask raycastLayer;

    [Header("Booleanos")]
    bool segundoEstagio;
    public bool podeAtirar = true;

    private void Awake()
    {
        jumpingIntervalAtual = jumpingInterval;
    }

    private void Update()
    {
        bool wallCheck = Physics2D.Raycast(transform.position, transform.right, raycastDistance, raycastLayer);

        if (wallCheck)
        {
            Flip();
        }
        if (jumpingIntervalAtual <= 0)
        {
            Jump();
            jumpingIntervalAtual = jumpingInterval;
        }
        if (bossHealth.vidaAtual <= bossHealth.maxHealth / 2)
        {
            segundoEstagio = true;
            SegundoEstagio();           
        }
        else
        {
            jumpingIntervalAtual -= Time.deltaTime;
        }
    }




    [ContextMenu("Pulo")]
    void Jump()
    {
        if (!segundoEstagio)
        {
            source.volume = 0.4f;
            source.pitch = 1;
            source.PlayOneShot(jump);
            Vector2 jumpDirection = new Vector2(transform.right.x * jumpForceDirection.x, jumpForceDirection.y);
            rigiBody2D.AddForce(jumpDirection);
        }
    }

    void Flip()
    {
        float bossDirection = 0;
        if (transform.rotation.y == 0)
        {
            bossDirection = 180;
        }

        transform.rotation = Quaternion.Euler(0, bossDirection, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * raycastDistance);
    }
    void AtiradorDeFogo()
    {
        if (podeAtirar)
        {
            source.volume = 0.6f;
            source.pitch = 1;
            source.PlayOneShot(fire);
            anim.SetInteger("Transition", 1);
            BolaDeFogo novaBola = Instantiate(bolaDeFogo, transform.position, Quaternion.identity).GetComponent<BolaDeFogo>();
            novaBola.alvo = player;
            podeAtirar = false;
            Invoke("ResetPodeAtirar", tempoParaProximoTiro); 
        }
    }

    void ResetPodeAtirar()
    {
        podeAtirar = true;
    }

    void SegundoEstagio()
    {
        AtiradorDeFogo();
    }
}