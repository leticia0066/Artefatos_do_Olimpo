using UnityEngine;

public class Zeus : MonoBehaviour
{
    public int health = 20;

    public GameObject exitDoor;
    public GameObject lightningManager;
    public GameObject healthBar;

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
        Debug.Log("⚡ Zeus derrotado!");

        if (lightningManager != null)
            Destroy(lightningManager);

        if (healthBar != null)
            healthBar.SetActive(false);

        if (exitDoor != null)
            exitDoor.SetActive(false); // libera saída

        Destroy(gameObject);
    }
}