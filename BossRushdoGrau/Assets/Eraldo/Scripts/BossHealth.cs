using UnityEngine;
using UnityEngine.SceneManagement;
public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    int vidaAtual; 

    void Start()
    {
        vidaAtual = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        vidaAtual -= damage; 

        
        if (vidaAtual <= 0)
        {
            Die();
            SceneManager.LoadScene(2);
            
        }
    }

    void Die()
    {
        Destroy(gameObject); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flecha"))
        {
            TakeDamage(100);
        }
    }
}

