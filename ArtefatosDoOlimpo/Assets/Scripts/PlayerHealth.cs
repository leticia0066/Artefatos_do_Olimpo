using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Vidas")]
    public int lives = 3;

    [Header("UI")]
    public HeartUI heartUI;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();

        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        currentHealth = maxHealth;

        UpdateHearts();

        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.checkpointPosition;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        // volta pro início do jogo (troque o nome se precisar)
        SceneManager.LoadScene("Fase1_Ares");
    }

    void UpdateHearts()
    {
        if (heartUI != null)
        {
            heartUI.UpdateHearts(lives);
        }
    }
}