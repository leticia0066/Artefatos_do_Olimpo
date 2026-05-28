using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Vidas")]
    public int lives = 3;

    [Header("UI")]
    public PlayerHealthBar healthBar;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();

        // Atualiza barra
        if (healthBar != null)
        {
            healthBar.Set(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Atualiza barra
        if (healthBar != null)
        {
            healthBar.Set(currentHealth);
        }

        // Morreu
        if (currentHealth <= 0)
        {
            lives--;

            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                GameOver();
            }
        }
    }

    void Respawn()
    {
        // Restaura vida
        currentHealth = maxHealth;

        // Atualiza barra
        if (healthBar != null)
        {
            healthBar.Set(currentHealth);
        }

        // Move pro checkpoint
        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.checkpointPosition;
        }

        // Reseta física
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
    }
}