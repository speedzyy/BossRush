using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    public float maxHp = 200;
    public float currentHp;
    public Image redbar;
    public Text health;
    [SerializeField] DemonController demonController;
    [SerializeField] Animator anim;

    void Awake()
    {
        currentHp = maxHp;
    }
    
    void Update()
    {
        UpdateHealthBar();
        UpdateHealth((int)currentHp, (int)maxHp);
    }

    void UpdateHealthBar()
    {
        redbar.fillAmount = currentHp / maxHp;
    }

    void UpdateHealth(int value, int valueMax)
    {
        health.text = value.ToString() + "/" + valueMax.ToString();
    }
    
    public void TakeDamage(int damage)
    {
        currentHp -= damage;


        if (currentHp <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        if (currentHp <= 0)
        {
            demonController.canShoot = false;
            anim.SetInteger("transition", 2);
            Destroy(gameObject, 2f);
            SceneManager.LoadScene(0);
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
