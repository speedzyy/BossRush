using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float vidaAtual;
    public Image redbar;
    public Text vida;
    [SerializeField] BossController bossController;
    [SerializeField] Animator anim;
    

    void Start()
    {
        vidaAtual = maxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
        UpdateLives((int)vidaAtual, (int)maxHealth);
    }

    private void UpdateHealthBar()
    {
        redbar.fillAmount =  vidaAtual / maxHealth;
    }
    private void UpdateLives(int value, int valueMax)
    {
        vida.text = value.ToString() + "/" + valueMax.ToString();
        
    }

    public void TakeDamage(int damage)
    {
        vidaAtual -= damage;


        if (vidaAtual <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (vidaAtual <= 0)
        {
            bossController.podeAtirar = false;
            anim.SetInteger("Transition", 2);
            Destroy(gameObject, 2f);
            SceneManager.LoadScene(2);
        }
        
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flecha"))
        {
            //SE O NUMERO DO DANO TIVER DIFERENTE DE 8 FOI POR CAUSA DE TESTES
            TakeDamage(8);
            //anim.SetBool()
        }
    }

}

