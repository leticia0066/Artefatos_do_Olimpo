using UnityEngine;

public class Zeus : MonoBehaviour
{
    public int health = 30;

    public GameObject exitDoor;
    public GameObject lightningManager;
    public GameObject healthBar;

    private bool enraged = false;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Zeus HP: " + health);

        if (health <= 15 && !enraged)
        {
            enraged = true;

            LightningSpawner spawner =
                FindObjectOfType<LightningSpawner>();

            if (spawner != null)
            {
                spawner.spawnInterval = 1f;
            }

            Debug.Log("ZEUS ENTROU EM MODO FÚRIA!");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("ZEUS DERROTADO!");

        if (lightningManager != null)
            Destroy(lightningManager);

        if (healthBar != null)
            healthBar.SetActive(false);

        if (exitDoor != null)
            exitDoor.SetActive(false);

        Destroy(gameObject);
    }
}