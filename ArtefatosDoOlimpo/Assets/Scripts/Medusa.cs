using UnityEngine;

public class Medusa : MonoBehaviour
{
    public int maxHealth = 10;
    private int health;

    public GameObject bossDoor;
    public GameObject healthBarUI;

    void Start()
    {
        health = maxHealth;

        if (healthBarUI != null)
            healthBarUI.SetActive(false);
    }

    public void ActivateBoss()
    {
        if (healthBarUI != null)
            healthBarUI.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (bossDoor != null)
            bossDoor.SetActive(false);

        if (healthBarUI != null)
            healthBarUI.SetActive(false);

        Destroy(gameObject);
    }
}