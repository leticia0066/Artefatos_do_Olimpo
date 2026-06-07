using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 8;
    private int currentHealth;

    public GameObject bossWall;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Medusa tomou dano!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Medusa morreu!");

        if (bossWall != null)
        {
            bossWall.SetActive(false);
        }

        Destroy(gameObject);
    }
}