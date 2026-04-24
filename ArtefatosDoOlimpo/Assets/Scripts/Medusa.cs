using UnityEngine;

public class Medusa : MonoBehaviour
{
    public int health = 10;

    [Header("Referências")]
    public GameObject bossDoor;

    private bool isDead = false;

    void Start()
    {
        if (bossDoor != null)
            bossDoor.SetActive(true); // começa fechada
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("🐍 Medusa derrotada!");

        // 🔓 abre a porta
        if (bossDoor != null)
        {
            bossDoor.SetActive(false);
        }

        Destroy(gameObject);
    }
}