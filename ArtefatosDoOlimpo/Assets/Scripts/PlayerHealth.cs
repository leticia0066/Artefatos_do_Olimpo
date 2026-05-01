using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;
    public int lives = 3;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            lives--;

            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                if (GameManager.instance != null)
                    GameManager.instance.GameOver();
            }
        }
    }

    void Respawn()
    {
        health = maxHealth;

        if (GameManager.instance != null)
        {
            GameManager.instance.RespawnPlayer(gameObject);
        }
        else
        {
            Debug.LogError("GameManager NÃO encontrado!");
        }
    }
}